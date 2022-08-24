using AutoMapper;
using RegionSyd.Common.DTOs;
using RegionSyd.Repositories;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
            _mapper = mapper;
        }
        public async Task<BookingDTO> CreateBooking(BookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            var returnBooking = await _bookingRepository.CreateBooking(booking);
            return _mapper.Map<BookingDTO>(returnBooking);
        }
        public async Task<List<BookingDTO>> GetBookings()
        {
            var bookings = await _bookingRepository.GetBookings();
            return _mapper.Map<List<BookingDTO>>(bookings);
        }
        public async Task<List<BookingDTO>> GetBookingsForPatientByID(int id)
        {
            var bookings = await _bookingRepository.GetBookingsForPatientByID(id);
            return _mapper.Map<List<BookingDTO>>(bookings);
        }
        public async Task<List<BookingDTO>> GetBookingsByDate(DateTime date)
        {
            var bookings = await _bookingRepository.GetBookingsByDate(date);
            return _mapper.Map<List<BookingDTO>>(bookings);
        }
        public async Task<List<BookingDTO>> GetBookingsForDepartmentByDate(TreatmentDTO treatmentDTO, DateTime date)
        {
            var treatment = _mapper.Map<Treatment>(treatmentDTO);
            var bookings = await _bookingRepository.GetBookingsForDepartmentByDate(treatment, date);
            return _mapper.Map<List<BookingDTO>>(bookings);
        }
        public async Task<BookingDTO> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return _mapper.Map<BookingDTO>(booking);
        }
        public async Task<bool> DeleteBooking(int id)
        {
            return await _bookingRepository.DeleteBooking(id);
        }

        public async Task<BookingDTO> UpdateBooking(BookingDTO bookingDTO)
        {
            Booking booking = _mapper.Map<Booking>(bookingDTO);
            Booking returnBooking = await _bookingRepository.UpdateBooking(booking);
            return _mapper.Map<BookingDTO>(returnBooking);
        }
    }
}
