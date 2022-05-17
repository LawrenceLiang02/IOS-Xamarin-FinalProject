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
    public partial class CreateOwnerPage : ContentPage
    {
        public CreateOwnerPage()
        {
            InitializeComponent();
            this.BindingContext = new CreateOwnerViewModel(NetworkService.Instance);
        }
    }
}