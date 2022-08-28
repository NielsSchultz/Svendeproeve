using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RegionSydDBContext _context;

        public PatientRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Patient> CreatePatient(Patient newPatient)
        {
            if (newPatient != null)
            {
                _context.Patients.Add(newPatient);
                await _context.SaveChangesAsync();
                return newPatient;
            }
            else
            {
                throw new ArgumentNullException(nameof(newPatient));
            }
        }

        public async Task<bool> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(patient));
            }
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _context.Patients.Where(p => p.PatientId == id)
                .Include(p => p.User)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _context.Patients
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Patient> UpdatePatient(Patient newPatient)
        {
            if (newPatient != null)
            {
                _context.Patients.Update(newPatient);
                await _context.SaveChangesAsync();
                return newPatient;
            }
            else
            {
                throw new ArgumentNullException(nameof(newPatient));
            }
        }
    }
}
