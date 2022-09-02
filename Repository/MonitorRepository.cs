using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor = RegionSyd.Repositories.Entities.Monitor;

namespace RegionSyd.Repositories
{
    public class MonitorRepository : IMonitorRepository
    {
        private readonly RegionSydDBContext _context;

        public MonitorRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Monitor> CreateMonitor(Monitor newMonitor)
        {
            if (newMonitor != null)
            {
                _context.Monitors.Add(newMonitor);
                await _context.SaveChangesAsync();
                return newMonitor;
            }
            else
            {
                throw new ArgumentNullException(nameof(newMonitor));
            }
        }

        public async Task<bool> DeleteMonitor(int id)
        {
            var monitor = await _context.Monitors.FindAsync(id);
            if (monitor != null)
            {
                _context.Monitors.Remove(monitor);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(monitor));
            }
        }

        public async Task<Monitor> GetMonitorByPatientID(int id)
        {
            return await _context.Monitors.Where(m => m.PatientId == id).FirstOrDefaultAsync();
        }

        public async Task<Monitor> GetMonitor(int id)
        {
            return await _context.Monitors.FindAsync(id);
        }

        public async Task<List<Monitor>> GetMonitors()
        {
            return await _context.Monitors.ToListAsync();
        }

        public async Task<Monitor> UpdateMonitor(Monitor newMonitor)
        {
            if (newMonitor != null)
            {
                _context.Monitors.Update(newMonitor);
                await _context.SaveChangesAsync();
                return newMonitor;
            }
            else
            {
                throw new ArgumentNullException(nameof(newMonitor));
            }
        }
    }
}
