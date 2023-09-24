using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Location;
using Models.Concrete.RequestModels.Update.Location;
using Repositories.Abstract;
using Repositories.Concrete.EFCore;

namespace Services.Abstract
{
    public interface ILocationService
    {
        Task CreateAsync(LocationRequestForInsertion locationRequestForInsertion);
        Task<bool> DeleteByIdAsync(int id);
        Task<Location> FindByIdAsync(int id);
        Task<(LocationRequestForUpdate locationRequestForUpdate, Location location)> GetLocationForPatchAsync(int id);
        Task SaveChangesForPatchAsync(LocationRequestForUpdate locationRequestForUpdate, Location location);
        Task UpdateAsync(int locationId, LocationRequestForUpdate locationRequestForUpdate);
    }
}