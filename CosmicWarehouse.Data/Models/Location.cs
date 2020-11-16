using System;
using System.Collections.Generic;

#nullable disable

namespace CosmicWarehouse.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
