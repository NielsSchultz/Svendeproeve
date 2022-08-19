using System;
using System.Collections.Generic;
using RegionSyd.Repositories.Entities;

namespace RegionSyd.Common.DTOs
{
    public class BookingOptionsDTO
    {
        public List<TreatmentDTO> treatments = new List<TreatmentDTO>();
        public List<TreatmentPlaceDTO> treatmentPlaces = new List<TreatmentPlaceDTO>();
        public List<DateTime> calendar = new List<DateTime>();
    }
}
