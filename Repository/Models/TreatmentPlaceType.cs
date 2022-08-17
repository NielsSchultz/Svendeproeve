using System;
using System.Collections.Generic;

namespace RegionSyd.Repositories.Models
{
    public partial class TreatmentPlaceType
    {
        public TreatmentPlaceType()
        {
            TreatmentPlaces = new HashSet<TreatmentPlace>();
        }

        public int TreatmentPlaceTypeId { get; set; }
        public string TreatmentPlaceTypeName { get; set; } = null!;

        public virtual ICollection<TreatmentPlace> TreatmentPlaces { get; set; }
    }
}
