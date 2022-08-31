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
    public class BedService : IBedService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Bed";

        public BedService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<BedDTO>> GetAll()
        {
            var beds = new List<BedDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                beds = JsonConvert.DeserializeObject<List<BedDTO>>(await content);
            }

            return beds;
        }

        public async Task<BedDTO> GetById(int id)
        {
            BedDTO bed = new BedDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var url = $"{httpClient.BaseAddress}{CONTROLLER}/{id}";

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/ByPatient/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                bed = JsonConvert.DeserializeObject<BedDTO>(await content);
            }

            return bed;
        }

        public async Task<BedDTO> Create(BedDTO bedDTO)
        {
            var bed = new BedDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(bedDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                bed = JsonConvert.DeserializeObject<BedDTO>(await content);
            }

            return bed;
        }
        public async Task<BedDTO> Update(BedDTO bedDTO)
        {
            var bed = new BedDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(bedDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                bed = JsonConvert.DeserializeObject<BedDTO>(await content);
            }

            return bed;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Seng er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }
    }
}
