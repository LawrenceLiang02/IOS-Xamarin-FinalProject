using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFinal.Models;
using XamarinFinal.Services.NetworkService;

namespace XamarinFinal.ViewModels
{
    public class UpdateOwnerViewModel : ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;

        private int id;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }

        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get => selectedOwner;
            set => SetProperty(ref selectedOwner, value);
        }

        public AsyncCommand UpdateOwnerCommand { get; }

        public UpdateOwnerViewModel(int id, INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;
            this.id = id;
            
            UpdateOwnerCommand = new AsyncCommand(UpdateOwner);
            GetOwnerWithId(id, networkService);
        }

        private async void GetOwnerWithId(int id, INetworkService<HttpResponseMessage> networkService)
        {
            SelectedOwner = await networkService.GetAsync<Owner>(APIConstants.GetOwnerById(id));
            SetOwnerDetails();
        }

        public void SetOwnerDetails()
        {
            FirstName = SelectedOwner.firstName;
            LastName = SelectedOwner.lastName;
            Address = SelectedOwner.address;
            City = SelectedOwner.city;
            Telephone = SelectedOwner.telephone;
        }
        private async Task UpdateOwner()
        {
            var result = await networkService.PutOwnerAsync(APIConstants.PutOwner(id), FirstName, LastName, Address, City, Telephone);

            if (result.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Sucess", "User #" + id + " Successfully Updated", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Failed with error code " + result.StatusCode, "Ok");
            }
            await Shell.Current.GoToAsync("..");

        }
    }
}
