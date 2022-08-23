using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartment(Department newDepartment);
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
        Task<List<Department>> GetDepartmentsForTreatmentPlace(int id);
        Task<Department> UpdateDepartment(Department newDepartment);
        Task<bool> DeleteDepartment(int id);
    }
}
