using MvvmHelpers;
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
    public class ViewOwnerViewModel : ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;

        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get => selectedOwner;
            set => SetProperty(ref selectedOwner, value);
        }

        public AsyncCommand OwnerSelectionCommand { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Owner> DeleteOwnerCommand { get; }

        public AsyncCommand<Owner> UpdateOwnerCommand { get; }

        public ObservableRangeCollection<Owner> Items { get; set; }

        public ViewOwnerViewModel(INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;
            
            OwnerSelectionCommand = new AsyncCommand(SelectOwner);
            RefreshCommand = new AsyncCommand(RefreshPage);
            DeleteOwnerCommand = new AsyncCommand<Owner>(DeleteOwner);
            UpdateOwnerCommand = new AsyncCommand<Owner>(RerouteUpdateOwnerPage);
            GetOwners();

        }

        private async Task RerouteUpdateOwnerPage(Owner owner)
        {
            if (owner == null)
            {
                return;
            }
            var route = $"{nameof(UpdateOwnerPage)}?id={owner.id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task DeleteOwner(Owner owner)
        {
            bool delete = await Shell.Current.DisplayAlert("Delete", "Are you sure you want to delete this user?", "Yes", "Cancel");

            if (delete)
            {
                var result = await networkService.DeleteAsync(APIConstants.DeleteOwner(owner.id));


                if (result.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Success", "The user has been deleted from the database.", "Ok!");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "There is an error deleting this user. Status code: " + result.StatusCode, "Ok!");
                }
                await GetOwners();
            }
            else
            {
                return;
            }
        }

        private async Task RefreshPage()
        {
            IsBusy = true;
            await GetOwners();
            IsBusy = false; 
        }

        private async Task SelectOwner()
        {
            if (SelectedOwner == null)
            {
                return;
            }
            var route = $"{nameof(ViewOwnerDetailPage)}?id={SelectedOwner.id}";
            SelectedOwner = null;
            await Shell.Current.GoToAsync(route);
        }

        private async Task GetOwners()
        {
            var result = await networkService.GetAsync<List<Owner>>(APIConstants.GetOwners());

            if (result == null)
            {
                return;
            }
            Items = new ObservableRangeCollection<Owner>(result);
            OnPropertyChanged("Items");
        }
    }
}
