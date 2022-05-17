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
    public partial class ViewOwnerDetailPage : ContentPage
    {
        public int id { get; set; }
        public ViewOwnerDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ViewOwnerDetailViewModel(id, NetworkService.Instance);
        }
    }
}