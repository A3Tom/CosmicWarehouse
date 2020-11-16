namespace CosmicWarehouse.App.ViewModels
{
    public class StockVM
    {
        public int StockId { get; init; }
        public int ItemId { get; init; }
        public int LocationId { get; init; }
        public int WarehouseId { get; init; }

        public decimal Weight { get; init; }

        public string ItemName { get; init; }
        public string ItemDescription { get; init; }
        public string LocationName { get; init; }
        public string WarehouseName { get; init; }
    }
}
