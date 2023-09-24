using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Award;
using Models.Concrete.RequestModels.Update.Award;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class AwardManager : IAwardService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AwardManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(AwardRequestForInsertion awardRequestForInsertion)
        {
            var award = _mapper.Map<Award>(awardRequestForInsertion);

            await _repositoryManager.Award.CreateAsync(award);
            await _repositoryManager.SaveAsync();

        }

        public Task CreateAsync(Award award)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIdAsync(int awardTypeId, int movieId)
        {
            var award = await _repositoryManager.Award.FindAsync(awardTypeId, movieId);

            var result = _repositoryManager.Award.Remove(award);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<Award> FindByIdAsync(int awardTypeId, int movieId)

          => await _repositoryManager.Award.FindAsync(awardTypeId, movieId);

        public async Task UpdateAsync(int awardTypeId, int movieId, AwardRequestForUpdate awardRequestForUpdate)
        {
            var award = await _repositoryManager.Award.FindAsync(awardTypeId,movieId);

            if (award is null)
                throw new Exception();

            award = _mapper.Map<Award>(awardRequestForUpdate);

            _repositoryManager.Award.Update(award);
            await _repositoryManager.SaveAsync();
        }
    }

}
