using System.Collections.Generic;

namespace CosmicWarehouse.Domain.Models
{
    public class WarehouseDto
    {
        public int Id { get; init; }
        public ICollection<LocationDto> Locations { get; init; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateDescription(string newDescripiton) => Description = newDescripiton;
    }
}
