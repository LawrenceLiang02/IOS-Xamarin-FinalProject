using System;
using System.Collections.Generic;
using System.Text;
using XamarinFinal.Models;

namespace XamarinFinal.Services.NetworkService
{
    public static class APIConstants
    {
        public static string Login()
        {
            return "http://10.0.2.2:80/login";
        }
        public static string GetOwners()
        {
            return "http://10.0.2.2:80/api/gateway/owners/";
        }

        public static string GetOwnerById(int id)
        {
            return $"http://10.0.2.2:80/api/gateway/owners/{id}";
        }

        public static string PostOwner()
        {
            return "http://10.0.2.2:80/api/gateway/owners/";
        }

        public static string PutOwner(int id)
        {
            return $"http://10.0.2.2:80/api/gateway/owners/{id}";
        }

        public static string DeleteOwner(int id)
        {
            return $"http://10.0.2.2:80/api/gateway/owners/{id}";
        }

        public static string GetPets(int ownerid)
        {
            return $"http://10.0.2.2:80/api/gateway/owners/{ownerid}/pets";
        }

    }
}
