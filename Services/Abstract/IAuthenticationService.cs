using Microsoft.AspNetCore.Identity;
using Models.Concrete.RequestModels.Insertion.User;
using Models.Concrete.RequestModels.Read.User;
using Models.Concrete.Tokens;

namespace Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegisterRequest userForRegister);
        Task<Token> CreateToken(bool populateExp);
        Task<Token> RefreshToken(Token token);
        Task<bool> ValidateUser(UserForAuthenticationRequest userForAuth);
    }
}
