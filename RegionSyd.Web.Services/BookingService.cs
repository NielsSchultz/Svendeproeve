using Newtonsoft.Json;
using RegionSyd.Common.DTOs;
using RegionSyd.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Web.Services
{
    public class BookingService : IBookingService
    {
        private IHttpClientFactory _httpClientFactory;
        private const string CONTROLLER = "Booking";

        public BookingService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<BookingDTO>> GetAll()
        {
            var bookings = new List<BookingDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                bookings = JsonConvert.DeserializeObject<List<BookingDTO>>(await content);
            }

            return bookings;
        }

        public async Task<BookingDTO> GetById(int id)
        {
            BookingDTO bookings = new BookingDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                bookings = JsonConvert.DeserializeObject<BookingDTO>(await content);
            }

            return bookings;
        }
        public async Task<List<BookingDTO>> GetByPatientId(int id)
        {
            List<BookingDTO> bookings = new List<BookingDTO>();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.GetAsync($"{httpClient.BaseAddress}{CONTROLLER}/ByPatient/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                bookings = JsonConvert.DeserializeObject<List<BookingDTO>>(await content);
            }

            return bookings;
        }

        public async Task<BookingDTO> Create(BookingDTO bookingDTO)
        {
            var booking = new BookingDTO();

            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");
            var httpResponseMessage = await httpClient.PostAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(bookingDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                booking = JsonConvert.DeserializeObject<BookingDTO>(await content);
            }

            return booking;
        }

        public async Task<BookingDTO> Update(BookingDTO bookingDTO)
        {
            var booking = new BookingDTO();
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.PutAsync($"{httpClient.BaseAddress}{CONTROLLER}", new StringContent(JsonConvert.SerializeObject(bookingDTO), Encoding.UTF8, "application/json"));

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var content = httpResponseMessage.Content.ReadAsStringAsync();

                booking = JsonConvert.DeserializeObject<BookingDTO>(await content);
            }

            return booking;
        }

        public async Task<string> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("RegionSydApi");

            var httpResponseMessage = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{CONTROLLER}/{id}");

            var message = httpResponseMessage.IsSuccessStatusCode ? "Booking er slettet" : "Der er sket en fejl prøv igen senere";

            return message; 
        }
    }
}
