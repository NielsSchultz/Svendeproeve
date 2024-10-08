﻿using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Entities
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
