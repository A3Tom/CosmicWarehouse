using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Domain.ViewModels
{
    public class StockVM
    {
        public int StockId { get; init; }
        public int ItemId { get; init; }
        public int LocationId { get; init; }
        public int WarehouseId { get; init; }

        public decimal Weight { get; init; }

        public bool Active { get; init; }

        public string ItemName { get; init; }
        public string ItemDescription { get; init; }
        public string LocationName { get; init; }
        public string WarehouseName { get; init; }

        public static implicit operator StockVM(ItemStock entity)
        {
            return new StockVM()
            {
                StockId = entity.Id,
                ItemId = entity.ItemId,
                ItemName = entity.Item.Name,
                ItemDescription = entity.Item.Description,
                Weight = entity.Weight,
                Active = entity.Active,

                LocationId = entity.Item.LocationId,
                LocationName = entity.Item.Location.Name,
                WarehouseId = entity.Item.Location.WarehouseId,
                WarehouseName = entity.Item.Location.Warehouse.Name
            };
        }
    }
}
