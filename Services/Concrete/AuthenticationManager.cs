using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Concrete.Domain;
using Models.Concrete.Exceptions.User;
using Models.Concrete.RequestModels.Insertion.User;
using Models.Concrete.RequestModels.Read.User;
using Models.Concrete.Tokens;
using Services.Abstract;
using Services.Aspects.Logging;
using Services.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        private User? _user;

        public AuthenticationManager(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        [LogAspect]
        public async Task<IdentityResult> RegisterUser(UserForRegisterRequest userForRegister)
        {
            var user = _mapper.Map<User>(userForRegister);

            var result = await _userManager.CreateAsync(user, userForRegister.Password);

            if (!result.Succeeded)
                throw new UserRegistrationException(result.Errors);

            await _userManager.AddToRoleAsync(user, Constants.User.DefaultRole);
            return result;
        }

        public async Task<Token> CreateToken(bool populateExp)
        {
            var signinCredentials = GetSigningCredentials();

            var claims = await GetClaims();

            var tokenOptions = TokenHelper.GenerateTokenOptions(signinCredentials, claims, _configuration);

            var refreshToken = TokenHelper.GenerateRefreshToken();

            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new Token()
            { AccessToken = accessToken, RefreshToken = refreshToken };

        }

        [LogAspect]
        public async Task<Token> RefreshToken(Token token)
        {
            var principal = TokenHelper.GetPrincipalFromExpiredToken(token.AccessToken, _configuration);

            var user = await _userManager.FindByEmailAsync(principal.Identity.Name);

            if (user is null ||
                user.RefreshToken != token.RefreshToken ||
                    user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new RefreshTokenBadRequestException("Invalid token");
            }

            _user = user;

            return await CreateToken(false);
        }

        [LogAspect]
        public async Task<bool> ValidateUser(UserForAuthenticationRequest userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.Username);

            if (_user is null)
                throw new UserNotFoundException(userForAuth.Username);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
                throw new InvalidCredentialsException();

            return result;
        }

        private async Task<IEnumerable<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,_user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetSection("secretKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha512);
        }

    }
}
