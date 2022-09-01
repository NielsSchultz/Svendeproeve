using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }
        [HttpPost]
        public async Task<BookingDTO> CreateBooking(BookingDTO newBooking)
        {
            return await _bookingService.CreateBooking(newBooking);
        }

        // Get all bookings
        [HttpGet]
        public async Task<List<BookingDTO>> GetBookings()
        {
            return await _bookingService.GetBookings();
        }

        // Get bookings by PatientID
        [HttpGet("ByPatient/{id}")]
        public async Task<List<BookingDTO>> GetBookingsForPatientByID(int id)
        {
            return await _bookingService.GetBookingsForPatientByID(id);
        }
        [HttpGet("ByDate/{id}")]
        // Get bookings by Date
        public async Task<List<BookingDTO>> GetBookingsByDate(DateTime date)
        {
            return await _bookingService.GetBookingsByDate(date);
        }

        // Get bookings by Date and Treatment Type
        [HttpGet("ByTreatmentDate/{id}")]
        public async Task<List<BookingDTO>> GetBookingsForDepartmentByDate(TreatmentDTO treatment, DateTime date)
        {
            return await _bookingService.GetBookingsForDepartmentByDate(treatment, date);
        }

        // Get booking by BookingID
        [HttpGet("{id}")]
        public async Task<BookingDTO> GetBookingById(int id)
        {
            return await _bookingService.GetBookingById(id);
        }

        // Edit booking
        [HttpPut]
        public async Task<BookingDTO> UpdateBooking(BookingDTO newBooking)
        {
            return await _bookingService.UpdateBooking(newBooking);
        }

        // Delete booking
        [HttpDelete]
        public async Task<bool> DeleteBooking(int id)
        {
            return await _bookingService.DeleteBooking(id);
        }
    }
}
