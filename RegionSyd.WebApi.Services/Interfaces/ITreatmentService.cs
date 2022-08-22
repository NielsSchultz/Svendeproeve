using RegionSyd.Common.DTOs;
using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.WebApi.Services.Interfaces
{
    public interface ITreatmentService
    {
        //fjern repository using efter treatment er mappet til DTO
        Task<List<Treatment>> GetTreatments();
        Task<Treatment> CreateTreatment(TreatmentDTO treatment);
    }
}
