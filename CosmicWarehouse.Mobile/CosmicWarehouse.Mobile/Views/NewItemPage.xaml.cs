using System;
using System.Collections.Generic;
using System.ComponentModel;
using CosmicWarehouse.Mobile.Models;
using CosmicWarehouse.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CosmicWarehouse.Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}