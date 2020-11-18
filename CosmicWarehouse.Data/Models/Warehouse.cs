using System.Collections.Generic;

#nullable disable

namespace CosmicWarehouse.Data.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
