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
    public class DepartmentService : IDepartmentService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Department";

        public DepartmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<DepartmentDTO> GetById(int id)
        {
            DepartmentDTO department = new DepartmentDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                department = JsonConvert.DeserializeObject<DepartmentDTO>(await content);
            }

            return department;
        }
        public async Task<List<DepartmentDTO>> GetDepartmentsForTreatmentPlace(int id)
        {
            List<DepartmentDTO> department = new List<DepartmentDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                department = JsonConvert.DeserializeObject<List<DepartmentDTO>>(await content);
            }

            return department;
        }

        public async Task<DepartmentDTO> Create(DepartmentDTO departmentDTO)
        {
            var journalEntry = new DepartmentDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(departmentDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalEntry = JsonConvert.DeserializeObject<DepartmentDTO>(await content);
            }

            return journalEntry;
        }
        public async Task<DepartmentDTO> Update(DepartmentDTO departmentDTO)
        {
            var journalEntry = new DepartmentDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(departmentDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                journalEntry = JsonConvert.DeserializeObject<DepartmentDTO>(await content);
            }

            return journalEntry;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Afdeling er slettet" : "Der er sket en fejl prøv igen senere";

            return message;
        }
    }
}
