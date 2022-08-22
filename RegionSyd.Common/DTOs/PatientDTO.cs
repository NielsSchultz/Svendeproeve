namespace RegionSyd.Common.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public int Cpr { get; set; }
        public DateTime Birthday { get; set; }
        public int UserId { get; set; }
        //User name (patient firstname, middlename, lastname)
        public string PatientName { get; set; } = null!;
    }
}
