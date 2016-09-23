using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessPratice.WebForm.Models
{
    public class LocationDTO
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string ZipCodePlusFour { get; set; }

    }
}