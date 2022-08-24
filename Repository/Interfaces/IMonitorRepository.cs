using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor = RegionSyd.Repositories.Entities.Monitor;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IMonitorRepository
    {
        // Create new Monitor
        Task<Monitor> CreateMonitor(Monitor newMonitor);

        // Get all Monitors
        Task<List<Monitor>> GetMonitors();

        // Get Monitor by ID
        Task<Monitor> GetMonitor(int id);

        // Get monitor by patient ID
        Task<Monitor> GetMonitorByPatientID(int id);

        // Update Monitor
        Task<Monitor> UpdateMonitor(Monitor newMonitor);

        // Delete Monitor
        Task<bool> DeleteMonitor(int id);
    }
}
