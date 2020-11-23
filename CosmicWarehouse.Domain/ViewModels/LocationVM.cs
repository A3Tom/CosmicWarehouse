using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Domain.ViewModels
{
    public class LocationVM
    {
        public int Id { get; init; }
        public int WarehouseId { get; init; }

        public string Name { get; init; }
        public string Description { get; init; }
        public string WarehouseName { get; init; }
        public string WarehouseDescription { get; init; }

        public bool Active { get; init; }


        public static implicit operator LocationVM(Location entity)
        {
            return new LocationVM()
            {
                Id = entity.Id,
                WarehouseId = entity.WarehouseId,
                Name = entity.Name,
                Description = entity.Description,
                Active = entity.Active,

                WarehouseName = entity.Warehouse?.Name,
                WarehouseDescription = entity.Warehouse?.Description
            };
        }
    }
}
