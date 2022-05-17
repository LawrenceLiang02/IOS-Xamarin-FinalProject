using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFinal.Views;

namespace XamarinFinal.ViewModels
{
    public class OwnerHomeViewModel : ViewModelBase
    {
        public AsyncCommand LogOutCommand { get; }

        public OwnerHomeViewModel()
        {
            LogOutCommand = new AsyncCommand(LogOut);
        }

        private async Task LogOut()
        {

            await Shell.Current.GoToAsync("..");
        }
    }
}
