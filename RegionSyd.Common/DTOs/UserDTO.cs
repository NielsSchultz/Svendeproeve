namespace RegionSyd.Common.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
