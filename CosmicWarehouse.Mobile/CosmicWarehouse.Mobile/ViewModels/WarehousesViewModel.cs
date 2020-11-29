using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CosmicWarehouse.Mobile.Models;
using CosmicWarehouse.Mobile.Services;
using Xamarin.Forms;

namespace CosmicWarehouse.Mobile.ViewModels
{
    public class WarehousesViewModel : BaseViewModel
    {
        private WarehouseDataService _dataService;

        private Warehouse _selectedItem;

        public ObservableCollection<Warehouse> Warehouses { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Warehouse> ItemTapped { get; }

        public WarehousesViewModel()
        {
            Title = "Browse motha fuckaaaa";
            Warehouses = new ObservableCollection<Warehouse>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<Warehouse>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var result = await _dataService.GetWarehouses();

                if(result.Any())
                {
                    foreach (var warehouse in result)
                    {
                        Warehouses.Add(warehouse);
                    }
                }

                Warehouses.Clear();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Warehouse SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                //OnItemSelected(value);
            }
        }

        //private async void OnAddItem(object obj)
        //{
        //    //await Shell.Current.GoToAsync(nameof(NewItemPage));
        //}

        //async void OnItemSelected(Item item)
        //{
        //    if (item == null)
        //        return;

        //    // This will push the ItemDetailPage onto the navigation stack
        //    //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        //}
    }
}
