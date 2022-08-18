﻿using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RegionSydDBContext _context;

        public BookingRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Booking> CreateBooking(Booking newBooking)
        {
            if(newBooking != null)
            {
                _context.Bookings.Add(newBooking);
                await _context.SaveChangesAsync();
                return newBooking;
            } else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.Where(b => b.BookingId == id).FirstOrDefaultAsync();
            if(booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                return true;
            } else
            {
                throw new ArgumentNullException(nameof(booking));
            }
        }

        public async Task<Booking> GetBookingById(int id)
        {
            return await _context.Bookings.Where(b => b.BookingId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Booking>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsForPatientByID(int id)
        {
            return await _context.Bookings.Where(b => b.PatientId == id).ToListAsync();
        }

        public async Task<Booking> UpdateBooking(Booking newBooking)
        {
            var booking = GetBookingById(newBooking.BookingId);
            if(booking != null)
            {
                _context.Bookings.Update(newBooking);
                await _context.SaveChangesAsync();
                return newBooking;
            } else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
