using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFinal.Models
{
    public class PetType
    {
        public PetType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}
