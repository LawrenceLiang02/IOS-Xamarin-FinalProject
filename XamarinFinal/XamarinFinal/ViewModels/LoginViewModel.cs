using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFinal.Services.NetworkService;
using XamarinFinal.Views;

namespace XamarinFinal.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;
        public AsyncCommand LoginCommand { get; }
        public string email { get; set; }
        public string password { get; set; }

        public LoginViewModel(INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;
            LoginCommand = new AsyncCommand(OnLoginClicked);
        }

        private async Task OnLoginClicked()
        {
            var result = await networkService.Login(APIConstants.Login(), email, password);

            if (result.IsSuccessStatusCode)
            {
                var route = $"{nameof(OwnerHomePage)}";
                await Shell.Current.GoToAsync(route);
            }

            else
            {
                await Shell.Current.DisplayAlert(result.StatusCode.ToString(), "Email or Password Incorrect", "Ok");
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        }
    }
}
