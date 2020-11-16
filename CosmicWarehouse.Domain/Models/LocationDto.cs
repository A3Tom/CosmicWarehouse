using System.Collections.Generic;

namespace CosmicWarehouse.Domain.Models
{
    public class LocationDto
    {
        public int Id { get; init; }
        public ICollection<ItemDto> Items { get; init; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateDescription(string newDescripiton) => Description = newDescripiton;
        public void AddItem(ItemDto newItem) => Items.Add(newItem);
    }
}
