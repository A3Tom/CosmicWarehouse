namespace CosmicWarehouse.Domain.Models
{
    public class LocationDto
    {
        public int Id { get; init; }
        public int WarehouseId { get; init; }

        public string Name { get; init; }
        public string Description { get; init; }
    }
}
