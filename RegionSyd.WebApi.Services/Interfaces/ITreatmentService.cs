using RegionSyd.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<List<TreatmentDTO>> GetTreatments();
        Task<TreatmentDTO> GetTreatmentById(int id);
        Task<TreatmentDTO> CreateTreatment(TreatmentDTO treatment);
        Task<TreatmentDTO> UpdateTreatment(TreatmentDTO treatment);
        Task<bool> DeleteTreatment(int id);
    }
}
