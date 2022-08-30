using Newtonsoft.Json;
using RegionSyd.Common.DTOs;
using RegionSyd.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Web.Services
{
    public class RoomService : IRoomService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Room";

        public RoomService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<RoomDTO>> GetAll()
        {
            var rooms = new List<RoomDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                rooms = JsonConvert.DeserializeObject<List<RoomDTO>>(await content);
            }

            return rooms;
        }

        public async Task<RoomDTO> GetById(int id)
        {
            RoomDTO room = new RoomDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var url = $"{httpClient.BaseAddress}{CONTROLLER}/{id}";

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                room = JsonConvert.DeserializeObject<RoomDTO>(await content);
            }

            return room;
        }

        public async Task<RoomDTO> Create(RoomDTO roomDTO)
        {
            var room = new RoomDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(roomDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                room = JsonConvert.DeserializeObject<RoomDTO>(await content);
            }

            return room;
        }
        public async Task<RoomDTO> Update(RoomDTO roomDTO)
        {
            var room = new RoomDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(roomDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                room = JsonConvert.DeserializeObject<RoomDTO>(await content);
            }

            return room;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Stue er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }


    }
}
}
