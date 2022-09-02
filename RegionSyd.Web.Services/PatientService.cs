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
    public class PatientService : IPatientService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Patient";

        public PatientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PatientDTO> GetById(int id)
        {
            PatientDTO patient = new PatientDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                patient = JsonConvert.DeserializeObject<PatientDTO>(await content);
            }

            return patient;
        }

        public async Task<PatientDTO> Create(PatientDTO patientDTO)
        {
            var patient = new PatientDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(patientDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                patient = JsonConvert.DeserializeObject<PatientDTO>(await content);
            }

            return patient;
        }
        public async Task<PatientDTO> Update(PatientDTO patientDTO)
        {
            var patient = new PatientDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(patientDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                patient = JsonConvert.DeserializeObject<PatientDTO>(await content);
            }

            return patient;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Patient er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }
    }
}
