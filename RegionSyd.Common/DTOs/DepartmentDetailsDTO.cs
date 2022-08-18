namespace RegionSyd.Common.DTOs
{
    public class DepartmentDetailsDTO
    {
        public DepartmentDTO department { get; set; } = null!;

        public List<TreatmentDTO> treatments { get; set; } = null!;

        public List<RoomDetailsDTO> roomDetails { get; set; } = null!;
    }
}
