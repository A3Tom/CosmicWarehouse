namespace CosmicWarehouse.Domain.Models
{
    public class WarehouseDto
    {
        public int? Id { get; init; }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
