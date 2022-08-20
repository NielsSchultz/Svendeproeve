using System;
using System.Collections.Generic;

namespace RegionSyd.Common.DTOs
{
    public class BookingOptionsDTO
    {
        // Slettes??
        public List<TreatmentDTO> treatments = new List<TreatmentDTO>();
        public List<TreatmentPlaceDTO> treatmentPlaces = new List<TreatmentPlaceDTO>();
        public List<DateTime> calendar = new List<DateTime>();
    }
}
