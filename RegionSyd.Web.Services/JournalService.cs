﻿using Newtonsoft.Json;
using RegionSyd.Common.DTOs;
using RegionSyd.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<JournalDTO> GetJournalById(int patientId)
        {
            JournalDTO journal = new JournalDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            // TODO JKL add the right api endpoint - and check if this enum work
            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{Controller.Journal.ToString()}/{patientId}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journal = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journal;
        }
        
        public async Task<JournalEntryDTO> SaveJournalEntry(JournalEntryDTO JournalEntryDTO)
        {
            var journalEntry = new JournalEntryDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            // TODO JKL add the right api endpoint
            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{Controller.Journal.ToString()}", new StringContent(JsonConvert.SerializeObject(JournalEntryDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalEntry = JsonConvert.DeserializeObject<JournalEntryDTO>(await content);
            }

            return journalEntry;
        }
    }
}