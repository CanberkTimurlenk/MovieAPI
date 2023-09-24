using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Award;
using Models.Concrete.RequestModels.Update.Award;

namespace Services.Abstract
{
    public interface IAwardService
    {
        Task CreateAsync(Award award);
        Task<bool> DeleteByIdAsync(int awardTypeId, int movieId);
        Task<Award> FindByIdAsync(int awardTypeId, int movieId);
        Task CreateAsync(AwardRequestForInsertion awardRequestForInsertion);
        Task UpdateAsync(int awardTypeId, int movieId, AwardRequestForUpdate awardRequestForUpdate);
    }
}