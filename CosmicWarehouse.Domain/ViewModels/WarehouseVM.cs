using System.Collections.Generic;
using System.Linq;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Domain.ViewModels
{
    public class WarehouseVM
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public IEnumerable<LocationVM> Locations { get; init; }

        //TODO : Move to automapper to flatten view models
        public static implicit operator WarehouseVM(Warehouse entity)
        {
            return new WarehouseVM()
            {
                Id = entity.Id,
                Name = entity.Name,
                Locations = entity.Locations.Select(x => (LocationVM)x)
            };
        }
    }
}
