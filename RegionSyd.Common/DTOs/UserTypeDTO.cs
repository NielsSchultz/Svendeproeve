using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class UserTypeDTO
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; } = null!;
    }
}
