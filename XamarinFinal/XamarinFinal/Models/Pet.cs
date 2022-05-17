using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFinal.Models
{
    public class Pet
    {
        public Pet(int id, string name, string birthDate, PetType type)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.type = type;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string birthDate { get; set; }
        public PetType type { get; set; }
    }
}
