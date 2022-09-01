namespace RegionSyd.Common.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        //user
        public int UserId { get; set; }
        public string Cpr { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string CityName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int? BedId { get; set; }
    }
}
