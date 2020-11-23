using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;

namespace CosmicWarehouse.Service.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationVM>> GetLocations(int? warehouseId);
        Task<LocationVM> AddLocation(LocationDto newLocation);
        Task<LocationVM> RenameLocation(LocationDto location);
        Task<LocationVM> ToggleActive(int locationId, bool active);
    }
}
