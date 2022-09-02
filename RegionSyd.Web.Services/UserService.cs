using Newtonsoft.Json;
using RegionSyd.Common.DTOs;
using RegionSyd.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Web.Services
{
    public class UserService : IUserService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "User";

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserDTO> GetById(int id)
        {
            UserDTO user = new UserDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<UserDTO>(await content);
            }

            return user;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = new UserDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(userDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<UserDTO>(await content);
            }

            return user;
        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = new UserDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(userDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<UserDTO>(await content);
            }

            return user;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Journal er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }
    }
}
