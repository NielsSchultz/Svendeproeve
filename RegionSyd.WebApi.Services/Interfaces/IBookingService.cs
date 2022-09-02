using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface IBookingService
    {
        // Create new booking
        Task<BookingDTO> CreateBooking(BookingDTO newBooking);

        // Get all bookings
        Task<List<BookingDTO>> GetBookings();

        // Get bookings by PatientID
        Task<List<BookingDTO>> GetBookingsForPatientByID(int id);

        // Get bookings by Date
        Task<List<BookingDTO>> GetBookingsByDate(DateTime date);

        // Get bookings by Date and Treatment Type
        Task<List<BookingDTO>> GetBookingsForDepartmentByDate(TreatmentDTO treatment, DateTime date);

        // Get booking by BookingID
        Task<BookingDTO> GetBookingById(int id);

        // Edit booking
        Task<BookingDTO> UpdateBooking(BookingDTO newBooking);

        // Delete booking
        Task<bool> DeleteBooking(int id);
    }
}
