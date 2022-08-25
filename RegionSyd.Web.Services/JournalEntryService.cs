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
    public class JournalEntryService : IJournalEntryService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "JournalEntry";
        public JournalEntryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<JournalEntryDTO> GetById(int id)
        {
            JournalEntryDTO journal = new JournalEntryDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalEntryDTO>(await content);
            }

            return journal;
        }

        public async Task<JournalEntryDTO> Create(JournalEntryDTO journalEntryDTO)
        {
            var journalEntry = new JournalEntryDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalEntryDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalEntry = JsonConvert.DeserializeObject<JournalEntryDTO>(await content);
            }

            return journalEntry;
        }
        public async Task<JournalEntryDTO> Update(JournalEntryDTO journalEntryDTO)
        {
            var journalEntry = new JournalEntryDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalEntryDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalEntry = JsonConvert.DeserializeObject<JournalEntryDTO>(await content);
            }

            return journalEntry;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Journal indlæg er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }
    }
}
