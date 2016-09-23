using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class Gym
    {
        public int GymId { get; set; }
        public string GymName { get; set; }
        public string GymAbbreviation { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

        public LocationCollection Locations { get; set; }

        public Gym()
        {
            this.Locations = new LocationCollection();
        }

    }
}
