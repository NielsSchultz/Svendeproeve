using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAll();
        Task<BookingDTO> GetById(int id);
        Task<List<BookingDTO>> GetByPatientId(int id);
        Task<BookingDTO> Create(BookingDTO bookingDTO);
        Task<BookingDTO> Update(BookingDTO bookingDTO);
        Task<string> Delete(int id);
    }
}