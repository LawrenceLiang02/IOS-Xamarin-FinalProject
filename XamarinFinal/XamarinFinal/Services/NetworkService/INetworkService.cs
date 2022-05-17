using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFinal.Services.NetworkService
{
    public interface INetworkService<HttpResponseMessage>
    {
        Task<HttpResponseMessage> Login(string uri, string email, string password);
        Task<TResult> GetAsync<TResult>(string uri);

        Task<HttpResponseMessage> PostOwnerAsync(string uri, string firstName, string lastName, string address, string city, string telephone);

        Task<HttpResponseMessage> PutOwnerAsync(string uri, string firstName, string lastName, string address, string city, string telephone);

        Task<HttpResponseMessage> DeleteAsync(string uri);
    }
}
