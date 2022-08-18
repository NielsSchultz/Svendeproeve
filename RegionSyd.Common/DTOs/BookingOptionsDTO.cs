using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class BookingOptionsDTO
    {
        public List<TreatmentDTO> treatments { get; set; } = null!;
        public List<TreatmentPlaceDTO> treatmentPlaces { get; set; } = null!;
        public List<DateTime> calendar { get; set; } = null!;
    }
}
