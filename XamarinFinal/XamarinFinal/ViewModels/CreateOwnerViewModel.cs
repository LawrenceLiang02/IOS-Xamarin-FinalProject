using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFinal.Services.NetworkService;

namespace XamarinFinal.ViewModels
{
    public class CreateOwnerViewModel : ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;
        public AsyncCommand CreateOwnerCommand { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }

        public CreateOwnerViewModel(INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;

            CreateOwnerCommand = new AsyncCommand(CreateOwner);
        }

        private async Task CreateOwner()
        {
            var result = await networkService.PostOwnerAsync(APIConstants.PostOwner(), FirstName, LastName, Address, City, Telephone);

            if (result.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Sucess", "User Successfully Create", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Failed with error code " + result.StatusCode, "Ok");
            }

        }
    }
}
