using AutoMapper;
using Models.Concrete.Entities;
using Repositories.Abstract;
using Services.Abstract;
using Models.Concrete.RequestModels.Insertion.Location;
using Models.Concrete.RequestModels.Update.Location;
using Models.Concrete.RequestModels.Update.Actor;

namespace Services.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public LocationManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(LocationRequestForInsertion locationRequestForInsertion)
        {
            var locationToCreate = _mapper.Map<LocationRequestForInsertion, Location>(locationRequestForInsertion);

            await _repositoryManager.Location.CreateAsync(locationToCreate);
            await _repositoryManager.SaveAsync();

        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var location = await _repositoryManager.Location.FindAsync(id);

            var result = _repositoryManager.Location.Remove(location);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<(LocationRequestForUpdate locationRequestForUpdate, Location location)> GetLocationForPatchAsync(int id)
        {
            var locationToUpdate = await _repositoryManager.Location.FindAsync(id);

            var locationRequestForUpdate = _mapper.Map<LocationRequestForUpdate>(locationToUpdate);

            return (locationRequestForUpdate, locationToUpdate);

        }

        public async Task SaveChangesForPatchAsync(LocationRequestForUpdate locationRequestForUpdate, Location location)
        {
            _mapper.Map(locationRequestForUpdate, location);
            await _repositoryManager.SaveAsync();
        }

        public async Task<Location> FindByIdAsync(int id)

          => await _repositoryManager.Location.FindAsync(id);

        public async Task UpdateAsync(int locationId, LocationRequestForUpdate locationRequestForUpdate)
        {
            var location = await _repositoryManager.Location.FindAsync(locationId);

            if (location is null)
                throw new Exception();

            location = _mapper.Map<Location>(locationRequestForUpdate);

            _repositoryManager.Location.Update(location);
            await _repositoryManager.SaveAsync();
        }
    }
}
