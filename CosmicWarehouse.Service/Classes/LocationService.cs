using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;
using CosmicWarehouse.Data.Repositories;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;
using CosmicWarehouse.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.Service.Classes
{
    public class LocationService : ILocationService
    {
        private readonly ILogger<LocationService> _logger;
        private readonly ICosmicWarehouseRepository _cosmicWarehouseRepo;

        public LocationService(ILogger<LocationService> logger,
            ICosmicWarehouseRepository cosmicWarehouseRepo)
        {
            _logger = logger;
            _cosmicWarehouseRepo = cosmicWarehouseRepo;
        }
        public async Task<IEnumerable<LocationVM>> GetLocations(int? warehouseId)
        {
            var result = await _cosmicWarehouseRepo.GetLocationsForWarehouse(warehouseId);

            return GetLocationListAsViewModel(result);
        }

        public async Task<LocationVM> AddLocation(LocationDto newLocation)
        {
            var newEntity = new Location()
            {
                Name = newLocation.Name,
                Description = newLocation.Description,
                WarehouseId = newLocation.WarehouseId
            };

            var result = await _cosmicWarehouseRepo.AddLocation(newEntity);

            return GetLocationAsViewModel(result);
        }

        public async Task<LocationVM> RenameLocation(LocationDto location)
        {
            var entity = await GetLocationEntity(location.Id);

            entity.Name = location.Name;
            entity.Description = location.Description;

            var result = await _cosmicWarehouseRepo.UpdateLocation(entity);

            return GetLocationAsViewModel(result);
        }

        public async Task<LocationVM> ToggleActive(int locationId, bool active)
        {
            var entity = await GetLocationEntity(locationId);

            entity.Active = active;

            var result = await _cosmicWarehouseRepo.UpdateLocation(entity);

            return GetLocationAsViewModel(result);
        }

        private async Task<Location> GetLocationEntity(int? locationId)
        {
            if (!locationId.HasValue)
                throw new InvalidOperationException($"No location Id supplied.");

            var entity = await _cosmicWarehouseRepo.GetLocation(locationId.Value);

            if (entity == null)
                throw new KeyNotFoundException($"No location was found with the Id of {locationId}");

            return entity;
        }

        private static IEnumerable<LocationVM> GetLocationListAsViewModel(IEnumerable<Location> locations)
        {
            return locations.Select(x => GetLocationAsViewModel(x));
        }

        private static LocationVM GetLocationAsViewModel(Location location)
        {
            return location;
        }
    }
}
