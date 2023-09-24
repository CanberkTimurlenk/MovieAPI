using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Update.AwardType;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class AwardTypeManager : IAwardTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AwardTypeManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(AwardTypeRequestForInsertion awardTypeRequestForInsertion)
        {
            var awardTypeToCreate = _mapper.Map<AwardType>(awardTypeRequestForInsertion);

            await _repositoryManager.AwardType.CreateAsync(awardTypeToCreate);
            await _repositoryManager.SaveAsync();

            return awardTypeToCreate.Id;

        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var award = await _repositoryManager.Award.FindAsync(id);

            var result = _repositoryManager.Award.Remove(award);

            await _repositoryManager.SaveAsync();

            return result;

        }
        public async Task<Award> FindByIdAsync(int id)

          => await _repositoryManager.Award.FindAsync(id);

        public async Task<(AwardTypeRequestForUpdate awardTypeRequestForUpdate, AwardType awardType)> GetAwardTypeForPatch(int id)
        {
            var awardTypeToUpdate = await _repositoryManager.AwardType.FindAsync(id);

            var awardTypeRequest = _mapper.Map<AwardTypeRequestForUpdate>(awardTypeToUpdate);

            return (awardTypeRequest, awardTypeToUpdate);

        }

        public async Task SaveChangesForPatchAsync(AwardTypeRequestForUpdate awardTypeRequestForUpdate, AwardType awardType)
        {
            _mapper.Map(awardTypeRequestForUpdate, awardType);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAsync(int awardTypeId, AwardTypeRequestForUpdate awardTypeRequestForUpdate)
        {
            var awardType = await _repositoryManager.AwardType.FindAsync(awardTypeId);

            if (awardType is null)
                throw new Exception();

            awardType = _mapper.Map<AwardType>(awardTypeRequestForUpdate);

            _repositoryManager.AwardType.Update(awardType);
            await _repositoryManager.SaveAsync();
        }
    }
}
