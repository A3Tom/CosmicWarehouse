using System.ComponentModel;
using CosmicWarehouse.Mobile.ViewModels;
using Xamarin.Forms;

namespace CosmicWarehouse.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}