using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Domain.ViewModels
{
    public class WarehouseVM
    {
        public int Id { get; init; }

        public string Name { get; init; }
        public string Description { get; init; }
        
        public bool Active { get; init; }


        public static implicit operator WarehouseVM(Warehouse entity)
        {
            return new WarehouseVM()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Active = entity.Active
            };
        }
    }
}
