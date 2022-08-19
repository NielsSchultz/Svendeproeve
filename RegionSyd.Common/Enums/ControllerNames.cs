using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Common.Enums
{
    public enum Controller
    {
        [EnumMember(Value = "Journal")]
        Journal, 
        Patient, 
        Employee,
        Bed,
        Monitor,
        Alarm
    }
}
