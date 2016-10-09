using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace VelocityCoders.FitnessPractice.Services.DataContracts
{
    [DataContract(Name = "InstructorDTO")]
    public class InstructorDTO
    {
        [DataMember]
        public int InstructorId {get;set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}