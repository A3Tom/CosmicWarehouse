using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace CosmicWarehouse.Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    class StockViewModel : BaseViewModel
    {
        private int itemId;
        private int locationId;
        private int? warehouseId;

        private int quantity;
        private decimal weight;

        private string itemName;
        private string itemDescription;
        private string locationName;
        private string warehouseName;

        public string Id { get; set; }

        public int LocationId
        {
            get => locationId;
            set => SetProperty(ref locationId, value);
        }

        public int? WarehouseId
        {
            get => warehouseId;
            set => SetProperty(ref warehouseId, value);
        }

        public int Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }

        public decimal Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public string ItemName
        {
            get => itemName;
            set => SetProperty(ref itemName, value);
        }

        public string ItemDescription
        {
            get => itemDescription;
            set => SetProperty(ref itemDescription, value);
        }
        public string LocationName
        {
            get => locationName;
            set => SetProperty(ref locationName, value);
        }
        public string WarehouseName
        {
            get => warehouseName;
            set => SetProperty(ref warehouseName, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

        public StockViewModel()
        {

        }
    }
}
