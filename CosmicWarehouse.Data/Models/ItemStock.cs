using System;
using System.Collections.Generic;

#nullable disable

namespace CosmicWarehouse.Data.Models
{
    public partial class ItemStock
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Weight { get; set; }
        public bool Active { get; set; }

        public virtual Item Item { get; set; }
    }
}
