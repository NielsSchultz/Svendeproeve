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
    public class TreatmentService : ITreatmentService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Treatment";

        public TreatmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TreatmentDTO>> GetAll()
        {
            List<TreatmentDTO> treatments = new List<TreatmentDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatments = JsonConvert.DeserializeObject<List<TreatmentDTO>>(await content);
            }

            return treatments;
        }

        public async Task<TreatmentDTO> GetById(int id)
        {
            var treatment = new TreatmentDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatment = JsonConvert.DeserializeObject<TreatmentDTO>(await content);
            }

            return treatment;
        }

        public async Task<TreatmentDTO> Create(TreatmentDTO treatmentDTO)
        {
            var treatment = new TreatmentDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(treatmentDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatment = JsonConvert.DeserializeObject<TreatmentDTO>(await content);
            }

            return treatment;
        }
        public async Task<TreatmentDTO> Update(TreatmentDTO treatmentDTO)
        {
            var treatment = new TreatmentDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(treatmentDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                treatment = JsonConvert.DeserializeObject<TreatmentDTO>(await content);
            }

            return treatment;
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


