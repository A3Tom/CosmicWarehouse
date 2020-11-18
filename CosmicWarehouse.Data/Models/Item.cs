using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CosmicWarehouse.Data.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemStocks = new HashSet<ItemStock>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
    }
}
