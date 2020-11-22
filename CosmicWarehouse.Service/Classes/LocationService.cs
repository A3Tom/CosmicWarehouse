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
        public Task<IEnumerable<LocationVM>> GetLocations(int? warehouseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<LocationVM> AddLocation(LocationDto newLocation)
        {
            throw new System.NotImplementedException();
        }

        public Task<LocationVM> Update(LocationDto location)
        {
            throw new System.NotImplementedException();
        }

        public Task<LocationVM> ToggleActive(int locationId, bool active)
        {
            throw new System.NotImplementedException();
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
