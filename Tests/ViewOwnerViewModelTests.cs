using System.Collections.Generic;
using XamarinFinal.Models;
using XamarinFinal.Services.NetworkService;
using XamarinFinal.ViewModels;
using Xunit;

namespace Tests
{
    public class ViewOwnerViewModelTests
    {
/*         [Fact]
       public void CheckSomeThing()
        {
            PetType type = new PetType(1, "dog");
            Pet pet1 = new Pet(1, "name", "birthDate", type);
            List<Pet> PetList1 = new List<Pet>();
            PetList1.Add(pet1);
            List<Visit> VisitList1 = new List<Visit>();
            Owner owner1 = new Owner(1, "fn", "ln", "address", "city", "telephone", PetList1, VisitList1);
            *//*List<Owner> ownerList = new List<Owner>;
            ownerList.Add(owner1);*//*

            ViewOwnerViewModel vm = new ViewOwnerViewModel(NetworkService.Instance);
            vm.SelectedOwner = owner1;

            Assert.Equal(1, vm.SelectedOwner.id);

        }*/

        [Fact]
        public void SelectedItem_empty()
        {
            //Arrange
            ViewOwnerViewModel vm = new ViewOwnerViewModel(NetworkService.Instance);

            //Assert
            Assert.Null(vm.SelectedOwner);
        }


        [Fact]
        public void CreateThenDeleteOwner()
        {
            //arrange
            PetType type = new PetType(1, "dog");
            Pet pet1 = new Pet(1, "name", "birthDate", type);
            List<Pet> PetList1 = new List<Pet>();
            PetList1.Add(pet1);
            List<Visit> VisitList1 = new List<Visit>();
            Owner owner1 = new Owner(1, "fn", "ln", "address", "city", "telephone", PetList1, VisitList1);

            //act
            ViewOwnerViewModel vm = new ViewOwnerViewModel(NetworkService.Instance);
            //act
            var result = vm.DeleteOwnerCommand.ExecuteAsync(owner1);
            //assert
            Assert.NotNull(result);
        }


        [Fact]
        public void Create_Then_UpdateOwner()
        {
            //arrange
            PetType type = new PetType(1, "dog");
            Pet pet1 = new Pet(1, "name", "birthDate", type);
            List<Pet> PetList1 = new List<Pet>();
            PetList1.Add(pet1);
            List<Visit> VisitList1 = new List<Visit>();
            Owner owner1 = new Owner(1, "fn", "ln", "address", "city", "telephone", PetList1, VisitList1);

            //act
            ViewOwnerViewModel vm = new ViewOwnerViewModel(NetworkService.Instance);
            //act
            var result = vm.UpdateOwnerCommand.ExecuteAsync(owner1);
            //assert
            Assert.NotNull(result);
        }


        [Fact]
        public void CreateThenSelectOwner()
        {
            //arrange
            PetType type = new PetType(1, "dog");
            Pet pet1 = new Pet(1, "name", "birthDate", type);
            List<Pet> PetList1 = new List<Pet>();
            PetList1.Add(pet1);
            List<Visit> VisitList1 = new List<Visit>();
            Owner owner1 = new Owner(1, "fn", "ln", "address", "city", "telephone", PetList1, VisitList1);

            //act
            ViewOwnerViewModel vm = new ViewOwnerViewModel(NetworkService.Instance);
            vm.SelectedOwner = owner1;
            //act
            var result = vm.OwnerSelectionCommand.ExecuteAsync();
            //assert
            Assert.NotNull(result);
        }
    }
}