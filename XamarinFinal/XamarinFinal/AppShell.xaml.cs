using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFinal.ViewModels;
using XamarinFinal.Views;

namespace XamarinFinal
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OwnerHomePage), typeof(OwnerHomePage));
            Routing.RegisterRoute(nameof(CreateOwnerPage), typeof(CreateOwnerPage));
            Routing.RegisterRoute(nameof(ViewOwnerDetailPage), typeof(ViewOwnerDetailPage));
            Routing.RegisterRoute(nameof(UpdateOwnerPage), typeof(UpdateOwnerPage));
            Routing.RegisterRoute(nameof(ViewOwnerpage), typeof(ViewOwnerpage));
            Routing.RegisterRoute(nameof(ViewPetsPage), typeof(ViewPetsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            //Routing.RegisterRoute(nameof(DeleteOwnerPage), typeof(DeleteOwnerPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
