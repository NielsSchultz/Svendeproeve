using RegionSyd.Common.Enums; 

namespace RegionSyd.Web.Models
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserTypes Usertype { get; set; }
    }
}
