using Grpc.Core;
using Protos;
using RegionSyd.Monitor.Server.Services.Interfaces;

namespace RegionSyd.Monitor.Server.Services

{
    public class PatientService : Patient.PatientBase
    {

        private readonly IBeds _beds;

        public PatientService(IBeds beds)
        {
            _beds = beds;

        }
        public override async Task<Response> AskForHelp(HelpRequest request, ServerCallContext context)
        {

            Response response = new();
            response.Received = true;
            _beds.UpdateBed(new Telemetrics { Alert = true, Bed = request.Bednumber });
            return await Task.FromResult(response);
        }
        public override async Task<Response> StopAskForHelp(HelpRequest request, ServerCallContext context)
        {

            Response response = new();
            response.Received = true;
            _beds.UpdateBed(new Telemetrics { Alert = false, Bed = request.Bednumber });
            return await Task.FromResult(response);
        }
        public override async Task<Response> AddBed(HelpRequest request, ServerCallContext context)
        {

            Response response = new();
            response.Received = true;
            _beds.AddBed(new Telemetrics { Alert = false, Bed = request.Bednumber });
            return await Task.FromResult(response);
        }

        public override async Task<IsNominalResponse> SendInfo(HeartRate patientInfo, ServerCallContext context)
        {
            IsNominalResponse response = new() { IsNominal = true };
            if (patientInfo.Heartrate < 60 || patientInfo.Heartrate > 140)
            {
                response.IsNominal = false;
                _beds.UpdateBed(new Telemetrics { Alert = true, Bed = patientInfo.Bednumber });
            }
            else
            {
                _beds.UpdateBed(new Telemetrics { Alert = false, Bed = patientInfo.Bednumber });
                response.IsNominal = true;
            }

            return await Task.FromResult(response);
        }
        public override async Task<TelemetricResponse> RequestTelemetrics(DepartmentNumber deptnumber, ServerCallContext context)
        {

            return await _beds.GetBeds();
        }
    }
}
