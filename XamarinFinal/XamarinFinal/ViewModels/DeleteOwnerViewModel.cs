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

namespace XamarinFinal.ViewModels
{
    public class DeleteOwnerViewModel : ViewModelBase
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

        public ObservableRangeCollection<Owner> Items { get; set; }

        public DeleteOwnerViewModel(INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;

            OwnerSelectionCommand = new AsyncCommand(DeleteOwner);
            RefreshCommand = new AsyncCommand(RefreshPage);
            GetOwners();

        }

        private async Task RefreshPage()
        {
            IsBusy = true;
            await GetOwners();
            IsBusy = false;
        }

        private async Task DeleteOwner()
        {
            bool delete = await Shell.Current.DisplayAlert("Delete", "Are you sure you want to delete this user?", "Yes", "Cancel");

            if (delete)
            {
                var result = await networkService.DeleteAsync(APIConstants.DeleteOwner(SelectedOwner.id));

                if (result == null)
                {
                    await Shell.Current.DisplayAlert("Success", "The user has been deleted from the database.", "Ok!");
                }
                await GetOwners();
            }
            else
            {
                return;
            }

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
