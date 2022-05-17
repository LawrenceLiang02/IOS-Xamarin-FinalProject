using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFinal.Models;
using XamarinFinal.Services.NetworkService;
using XamarinFinal.Views;

namespace XamarinFinal.ViewModels
{
    public class ViewOwnerDetailViewModel : ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;

        private int id;

        private Owner selectedOwner;

        public AsyncCommand GoBackCommand { get; }
        public AsyncCommand ViewPetsCommand { get; }
        public AsyncCommand UpdateOwnerCommand { get; }
        public AsyncCommand DeleteOwnerCommand { get; }

        public Owner SelectedOwner
        {
            get => selectedOwner;
            set => SetProperty(ref selectedOwner, value);
        }

        public ViewOwnerDetailViewModel(int id, INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;
            this.id = id;
            GoBackCommand = new AsyncCommand(GoBack);
            UpdateOwnerCommand = new AsyncCommand(UpdateOwner);
            DeleteOwnerCommand = new AsyncCommand(DeleteOwner);
            ViewPetsCommand = new AsyncCommand(ViewPets);
            SetUpAsync(id, networkService);
        }

        private async Task ViewPets()
        {
            var route = $"{nameof(ViewPetsPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task DeleteOwner()
        {
            bool delete = await Shell.Current.DisplayAlert("Delete", "Are you sure you want to delete this user?", "Yes", "Cancel");

            if (delete)
            {
                var result = await networkService.DeleteAsync(APIConstants.DeleteOwner(id));

                if (result.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Success", "The user has been deleted from the database.", "Ok!");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "There is an error deleting this user. Status code: " + result.StatusCode, "Ok!");
                }
                
            }
            else
            {
                return;
            }
            await Shell.Current.GoToAsync("..");
        }

        private async Task UpdateOwner()
        {

            var route = $"{nameof(UpdateOwnerPage)}?id={id}";
            await Shell.Current.GoToAsync(route);
        }

        private async void SetUpAsync(int id, INetworkService<HttpResponseMessage> networkService)
        {
            SelectedOwner = await networkService.GetAsync<Owner>(APIConstants.GetOwnerById(id));
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
