using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Update.AwardType;
using Services.Concrete;

namespace Services.Abstract
{
    public interface IAwardTypeService
    {
        Task<int> CreateAsync(AwardTypeRequestForInsertion awardTypeRequestForInsertion);
        Task<bool> DeleteByIdAsync(int id);
        Task<Award> FindByIdAsync(int id);
        Task<(AwardTypeRequestForUpdate awardTypeRequestForUpdate, AwardType awardType)> GetAwardTypeForPatch(int id);
        Task SaveChangesForPatchAsync(AwardTypeRequestForUpdate AwardTypeRequestForUpdate, AwardType awardType);
        Task UpdateAsync(int awardTypeId, AwardTypeRequestForUpdate awardTypeRequestForUpdate);
    }

}