﻿using Newtonsoft.Json;
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
    public class JournalService : IJournalService
    {
        private IHttpClientFactory _httpClientFactory;
        private string CONTROLLER = Controller.Journal.ToString();

        public JournalService(IHttpClientFactory httpClientFactory)
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

        public async Task<JournalDTO> Create(JournalDTO journalDTO)
        {
            var journalEntry = new JournalDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(journalDTO), Encoding.UTF8));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalEntry = JsonConvert.DeserializeObject<JournalDTO>(await content);
            }

            return journalEntry;
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
