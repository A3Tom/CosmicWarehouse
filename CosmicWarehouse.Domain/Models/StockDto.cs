namespace CosmicWarehouse.Domain.Models
{
    public class StockDto
    {
        public int? Id { get; init; }
        public int ItemId { get; init; }
        public int LocationId { get; init; }
        public int WarehouseId { get; init; }

        public decimal Weight { get; init; }

        public bool Active { get; init; }
    }
}
