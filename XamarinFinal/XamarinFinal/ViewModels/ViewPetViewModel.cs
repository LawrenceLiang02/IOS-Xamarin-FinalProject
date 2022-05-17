using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFinal.Models;
using XamarinFinal.Services.NetworkService;

namespace XamarinFinal.ViewModels
{
    public class ViewPetViewModel: ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;

        private int id;

        public ObservableRangeCollection<Pet> Items { get; set; }

        public AsyncCommand RefreshCommand { get; }

        private Pet selectedPet;

        public Pet SelectedPet
        {
            get => selectedPet;
            set => SetProperty(ref selectedPet, value);
        }

        public ViewPetViewModel(int id, INetworkService<HttpResponseMessage> networkService)
        {
            this.networkService = networkService;
            this.id = id;
            RefreshCommand = new AsyncCommand(RefreshPage);
            GetPets(id, networkService);
        }
        private async Task RefreshPage()
        {
            IsBusy = true;
            GetPets(id, networkService);
            IsBusy = false;
        }

        private async void GetPets(int id, INetworkService<HttpResponseMessage> networkService)
        {
            var result = await networkService.GetAsync<List<Pet>>(APIConstants.GetPets(id));
            if (result == null)
            {
                return;
            }
            Items = new ObservableRangeCollection<Pet>(result);
            OnPropertyChanged("Items");
        }

    }
}
