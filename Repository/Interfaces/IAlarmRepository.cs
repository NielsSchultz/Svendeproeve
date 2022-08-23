using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IAlarmRepository
    {
        Task<Alarm> CreateAlarm(Alarm newAlarm);
        Task<List<Alarm>> GetAlarms();
        Task<Alarm> GetAlarm(int id);
        Task<List<Alarm>> GetAlarmForBed(int id);
        Task<Alarm> UpdateAlarm(Alarm newAlarm);
        Task<bool> DeleteAlarm(int id);
    }
}
