using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFinal.Models
{
    public class OwnerWithoutId
    {
        public OwnerWithoutId(string firstName, string lastName, string address, string city, string telephone, List<Pet> pets)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.telephone = telephone;
            this.pets = pets;
   
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string telephone { get; set; }
        public List<Pet> pets { get; set; }

    }
}
