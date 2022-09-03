using Protos;
using RegionSyd.Monitor.Server.Services.Interfaces;

namespace RegionSyd.Monitor.Server.Services
{
    public class Beds : IBeds
    {
        //private readonly List<Telemetrics> beds;
        private readonly TelemetricResponse beds;
        public Beds()
        {
            beds = new();
            //beds.Telemetrics.Add(new Telemetrics { Alert = false, Bed = 1 })
        }

        public async void AddBed(Telemetrics tel)
        {
            if (beds.Telemetrics.Where(t => t.Bed == tel.Bed).FirstOrDefault() == null)
            {
                beds.Telemetrics.Add(tel);
            }

        }
        public async void UpdateBed(Telemetrics tel)
        {

            //var tele = beds.Telemetrics.Where(t => t.Bed == tel.Bed).FirstOrDefault();
            if (beds.Telemetrics.Where(t => t.Bed == tel.Bed).FirstOrDefault() != null)
            {
                beds.Telemetrics.Single(x => x.Bed == tel.Bed).Alert = tel.Alert;
            }

        }
        public async void RemoveBed(Telemetrics tel)
        {
            beds.Telemetrics.Remove(tel);
        }
        public async Task<TelemetricResponse> GetBeds()
        {
            return beds;
        }
    }
}
