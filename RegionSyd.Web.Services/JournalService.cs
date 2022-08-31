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
    public class JournalService : IJournalService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Journal";

        public JournalService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<JournalDTO>> GetAll()
        {
            var journals = new List<JournalDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journals = JsonConvert.DeserializeObject<List<JournalDTO>>(await content);
            }

            return journals;
        }

        public async Task<JournalDTO> GetById(int id)
        {
            JournalDTO journal = new JournalDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var url = $"{httpClient.BaseAddress}{CONTROLLER}/{id}";

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/ByPatient/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journal;
        } 
        
        public async Task<JournalDTO> GetByPatientId(int id)
        {
            JournalDTO journal = new JournalDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var url = $"{httpClient.BaseAddress}{CONTROLLER}/ByPatient/{id}";

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/ByPatient/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journal;
        }

        public async Task<JournalDTO> Create(JournalDTO journalDTO)
        {
            var journal = new JournalDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journal;
        }
        public async Task<JournalDTO> Update(JournalDTO journalDTO)
        {
            var journal = new JournalDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journal;
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
