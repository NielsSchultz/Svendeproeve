namespace RegionSyd.Common.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public int Cpr { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        //user
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
    }
}
