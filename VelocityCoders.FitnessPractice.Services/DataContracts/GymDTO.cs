using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{

    [DataContract(Name = "GymDTO")]
    public class GymDTO
    {
        [DataMember]
        public int GymId { get; set; }
        
        [DataMember]
        public string GymName { get; set; }

        [DataMember]
        public string GymAbbreviation { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Website { get; set; }

    }
}