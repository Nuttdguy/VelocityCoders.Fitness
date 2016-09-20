using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        public string City { get; set; } 
        public int ZipCode { get; set; }
        public int ZipCodePlusFour { get; set; }

    }
}
