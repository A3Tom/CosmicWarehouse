using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Domain.ViewModels
{
    public class StockVM
    {
        public int ItemId { get; init; }
        public int LocationId { get; init; }
        public int? WarehouseId { get; init; }

        public int Quantity { get; init; }
        public decimal Weight { get; init; }

        public string ItemName { get; init; }
        public string ItemDescription { get; init; }
        public string LocationName { get; init; }
        public string WarehouseName { get; init; }

        public static implicit operator StockVM(Item entity)
        {
            return new StockVM()
            {
                ItemId = entity.Id,
                ItemName = entity.Name,
                ItemDescription = entity.Description,
                Quantity = entity.Quantity,
                Weight = entity.Weight,

                LocationId = entity.LocationId,
                LocationName = entity.Location?.Name,
                WarehouseId = entity.Location?.WarehouseId,
                WarehouseName = entity.Location?.Warehouse.Name
            };
        }
    }
}
