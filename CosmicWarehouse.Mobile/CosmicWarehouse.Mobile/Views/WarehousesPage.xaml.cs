using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicWarehouse.Mobile.Models;
using CosmicWarehouse.Mobile.ViewModels;
using CosmicWarehouse.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CosmicWarehouse.Mobile.Views
{
    public partial class WarehousesPage : ContentPage
    {
        WarehousesViewModel _viewModel;

        public WarehousesPage()
        {
            //InitializeComponent();

            BindingContext = _viewModel = new WarehousesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}