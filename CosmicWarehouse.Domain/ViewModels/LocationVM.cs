using System.Collections.Generic;
using System.Linq;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Domain.ViewModels
{
    public class LocationVM
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public WarehouseVM Warehouse { get; init; }
        public IEnumerable<StockVM> Stock { get; init; }

        //TODO : Move to automapper to flatten view models
        public static implicit operator LocationVM(Location entity)
        {
            return new LocationVM()
            {
                Id = entity.Id,
                Name = entity.Name,
                Warehouse = entity.Warehouse,
                Stock = entity.Items.Select(x => (StockVM)x)
            };
        }
    }
}
