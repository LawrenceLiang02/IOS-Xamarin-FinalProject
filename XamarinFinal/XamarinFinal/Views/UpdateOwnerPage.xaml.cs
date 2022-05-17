using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFinal.Services.NetworkService;
using XamarinFinal.ViewModels;

namespace XamarinFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(id), nameof(id))]
    public partial class UpdateOwnerPage : ContentPage
    {
        public int id { get; set; }
        public UpdateOwnerPage()
        {
            InitializeComponent();
            //this.BindingContext = new UpdateOwnerViewModel(NetworkService.Instance);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new UpdateOwnerViewModel(id, NetworkService.Instance);
        }
    }
}