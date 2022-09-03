using Protos;

namespace RegionSyd.Monitor.Server.Services.Interfaces
{
    public interface IBeds
    {
        void AddBed(Telemetrics tel);
        void UpdateBed(Telemetrics tel);
        void RemoveBed(Telemetrics tel);
        Task<TelemetricResponse> GetBeds();
    }
}
