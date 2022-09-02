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
    public class AlarmRepository : IAlarmRepository
    {
        private readonly RegionSydDBContext _context;

        public AlarmRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Alarm> CreateAlarm(Alarm newAlarm)
        {
            if (newAlarm != null)
            {
                _context.Alarms.Add(newAlarm);
                await _context.SaveChangesAsync();
                return newAlarm;
            }
            else
            {
                throw new ArgumentNullException(nameof(newAlarm));
            }
        }

        public async Task<bool> DeleteAlarm(int id)
        {
            var alarm = await _context.Alarms.Where(b => b.AlarmId == id).FirstOrDefaultAsync();
            if (alarm != null)
            {
                _context.Alarms.Remove(alarm);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(alarm));
            }
        }

        public async Task<Alarm> GetAlarm(int id)
        {
            return await _context.Alarms.FindAsync(id);
        }

        public async Task<Alarm> GetAlarmForBed(int id)
        {
            return await _context.Alarms.Where(a => a.BedId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Alarm>> GetAlarms()
        {
            return await _context.Alarms.ToListAsync();
        }

        public async Task<Alarm> UpdateAlarm(Alarm newAlarm)
        {
            if (newAlarm != null)
            {
                _context.Alarms.Update(newAlarm);
                await _context.SaveChangesAsync();
                return newAlarm;
            }
            else
            {
                throw new ArgumentNullException(nameof(newAlarm));
            }
        }
    }
}
