using System;

#nullable disable

namespace CosmicWarehouse.Data.Models
{
    public partial class StockTransaction
    {
        public StockTransaction()
        {
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public int PreviousQuantity { get; set; }
        public int NewQuantity { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public virtual Item Item { get; set; }
    }
}
