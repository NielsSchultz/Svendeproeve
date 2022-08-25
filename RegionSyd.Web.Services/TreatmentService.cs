using Newtonsoft.Json;
using RegionSyd.Common.DTOs;
using RegionSyd.Common.Enums;
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
        private string CONTROLLER = Controller.Treatment.ToString();

        public TreatmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<JournalDTO> GetById(int id)
        {
            JournalDTO journal = new JournalDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            // TODO JKL add the right api endpoint - and check if this enum work
            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journal;
        }

        public async Task<TreatmentDTO> Create(TreatmentDTO treatmentDTO)
        {
            var treatment = new TreatmentDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(treatmentDTO), Encoding.UTF8));

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

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(treatmentDTO), Encoding.UTF8));

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


