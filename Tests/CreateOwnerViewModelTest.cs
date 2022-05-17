using System.Collections.Generic;
using XamarinFinal.Models;
using XamarinFinal.Services.NetworkService;
using XamarinFinal.ViewModels;
using Xunit;

namespace Tests
{
    public class CreateOwnerViewModelTest
    {
        [Fact]
        public void On_start_values_are_null()
        {
            //Arrange
            CreateOwnerViewModel vm = new CreateOwnerViewModel(NetworkService.Instance);

            //Assert
            Assert.Null(vm.FirstName);
            Assert.Null(vm.LastName);
            Assert.Null(vm.Address);
            Assert.Null(vm.City);
            Assert.Null(vm.Telephone);
        }
    }
}
