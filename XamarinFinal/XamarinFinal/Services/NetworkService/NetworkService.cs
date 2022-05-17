using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinFinal.Models;

namespace XamarinFinal.Services.NetworkService
{
    public sealed class NetworkService : INetworkService<HttpResponseMessage>
    {
        private static HttpClient httpClient;

        private static NetworkService instance = null;
        private static readonly object padlock = new object();

        private NetworkService()
        {
            httpClient = new HttpClient();
        }

        public static NetworkService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new NetworkService();
                    }
                    return instance;
                }
            }
        }



        public async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);


            return response;
            
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string serialize = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResult>(serialize);

            return result;
        }

        public async Task<HttpResponseMessage> Login(string uri, string email, string password)
        {


            var jsonData = new Dictionary<string, string>
            {
                {"email", email },
                {"password", password}
            };

            var json = JsonConvert.SerializeObject(jsonData);

            HttpContent headerContent = new StringContent(json);

            headerContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            HttpResponseMessage response = await httpClient.PostAsync(uri, headerContent);

            if (response.IsSuccessStatusCode)
            {
                HttpHeaders headers = response.Headers;
                IEnumerable<string> values;
                var jwt = "";

                if (headers.TryGetValues("Authorization", out values))
                {
                    jwt = values.First();
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return response;
            }

            return response;
        }

        public async Task<HttpResponseMessage> PostOwnerAsync(string uri, string firstName, string lastName, string address, string city, string telephone)
        {
            var item = new Dictionary<string, string>
            {
                {"firstName", firstName},
                {"lastName", lastName},
                {"address", address},
                {"city", city},
                {"telephone", telephone},
                {"pets", null }
            };

            var json = JsonConvert.SerializeObject(item);
            var bodyContent = new StringContent(json);

            bodyContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, bodyContent);

            //var result = await response.Content.ReadAsStringAsync();

            return response;
        }

        public async Task<HttpResponseMessage> PutOwnerAsync(string uri, string firstName, string lastName, string address, string city, string telephone)
        {
            var item = new Dictionary<string, string>
            {
                {"firstName", firstName},
                {"lastName", lastName},
                {"address", address},
                {"city", city},
                {"telephone", telephone},
                {"pets", null }
            };

            var json = JsonConvert.SerializeObject(item);
            var bodyContent = new StringContent(json);

            bodyContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PutAsync(uri, bodyContent);

            //var result = await response.Content.ReadAsStringAsync();

            return response;
        }
    }
}
