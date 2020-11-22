namespace CosmicWarehouse.Domain.Models
{
    public class StockDto
    {
        public int LocationId { get; init; }
        public int Quantity { get; init; }

        public string Name { get; init; }
        public string Description { get; init; }

        public decimal Weight { get; init; }

        public bool Active { get; init; }
    }
}
