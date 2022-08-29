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
    public class JournalNoteService : IJournalNoteService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "JournalEntryNote";
        public JournalNoteService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<JournalEntryNoteDTO>> GetAll(int id)
        {
            List<JournalEntryNoteDTO> notes = new List<JournalEntryNoteDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/ByJournalEntry/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                notes = JsonConvert.DeserializeObject<List<JournalEntryNoteDTO>>(await content);
            }

            return notes;
        }
        public async Task<JournalEntryNoteDTO> GetById(int id)
        {
            JournalEntryNoteDTO note = new JournalEntryNoteDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                note = JsonConvert.DeserializeObject<JournalEntryNoteDTO>(await content);
            }

            return note;
        }

        public async Task<JournalEntryNoteDTO> Create(JournalEntryNoteDTO journalNoteDTO)
        {
            var journalNote = new JournalEntryNoteDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalNoteDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalNote = JsonConvert.DeserializeObject<JournalEntryNoteDTO>(await content);
            }

            return journalNote;
        }
        public async Task<JournalEntryNoteDTO> Update(JournalEntryNoteDTO journalNoteDTO)
        {
            var journalNote = new JournalEntryNoteDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalNoteDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalNote = JsonConvert.DeserializeObject<JournalEntryNoteDTO>(await content);
            }

            return journalNote;
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

