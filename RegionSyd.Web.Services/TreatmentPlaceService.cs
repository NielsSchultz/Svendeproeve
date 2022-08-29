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
    public class TreatmentPlaceService : ITreatmentPlaceService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "TreatmentPlace";

        public TreatmentPlaceService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TreatmentPlaceDTO>> GetAll()
        {
            List<TreatmentPlaceDTO> treatmentPlaces = new List<TreatmentPlaceDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatmentPlaces = JsonConvert.DeserializeObject<List<TreatmentPlaceDTO>>(await content);
            }

            return treatmentPlaces;
        }

        public async Task<TreatmentPlaceDTO> GetById(int id)
        {
            var treatmentPlace = new TreatmentPlaceDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatmentPlace = JsonConvert.DeserializeObject<TreatmentPlaceDTO>(await content);
            }

            return treatmentPlace;
        }

        public async Task<TreatmentPlaceDTO> Create(TreatmentPlaceDTO treatmentPlaceDTO)
        {
            var treatmentPlace = new TreatmentPlaceDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(treatmentPlaceDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatmentPlace = JsonConvert.DeserializeObject<TreatmentPlaceDTO>(await content);
            }

            return treatmentPlace;
        }
        public async Task<TreatmentPlaceDTO> Update(TreatmentPlaceDTO treatmentPlaceDTO)
        {
            var treatmentPlace = new TreatmentPlaceDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(treatmentPlaceDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatmentPlace = JsonConvert.DeserializeObject<TreatmentPlaceDTO>(await content);
            }

            return treatmentPlace;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "undersøgelse er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }

    }
}
