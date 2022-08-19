using Newtonsoft.Json;
using RegionSyd.Common.DTOs;
using RegionSyd.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Web.Services
{
    public class JournalService
    {
        private IHttpClientFactory _httpClientFactory;
        //private const string CONTROLLER = "Journal";

        public JournalService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<JournalEntryDetailsDTO> GetJournalById(int patientId)
        {
            JournalEntryDetailsDTO journal = new JournalEntryDetailsDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            // TODO JKL add the right api endpoint - and check if this enum work
            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{Controller.Journal.ToString()}/{patientId}"); 

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalEntryDetailsDTO>(await content);
            }

            return journal;
        }
    }
}
