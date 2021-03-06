using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFinal.Services.NetworkService;
using XamarinFinal.ViewModels;

namespace XamarinFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewOwnerpage : ContentPage
    {
        public ViewOwnerpage()
        {
            InitializeComponent();
            BindingContext = new ViewOwnerViewModel(NetworkService.Instance);
        }
    }
}