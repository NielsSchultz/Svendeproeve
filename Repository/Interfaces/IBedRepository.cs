using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IBedRepository
    {
        Task<List<Bed>> GetBeds();
        Task<Bed> GetBedById(int id);
        Task<Bed> CreateBed(Bed bed);
        Task<Bed> UpdateBed(Bed bed);
        Task<bool> DeleteBed(int id);
        Task<List<Bed>> GetUnoccupiedBeds();
    }
}
