using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        // Create new booking
        Task<Booking> CreateBooking(Booking newBooking);

        // Get all bookings
        Task<List<Booking>> GetBookings();

        // Get bookings by PatientID
        Task<List<Booking>> GetBookingsForPatientByID(int id);

        // Get booking by BookingID
        Task<Booking> GetBookingById(int id);

        // Edit booking
        Task<Booking> UpdateBooking(Booking newBooking);

        // Delete booking
        Task<bool> DeleteBooking(int id);
    }
}
