using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{
    [DataContract]
    public class StateDTO
    {
        [DataMember]
        public int StateId { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public string StateAbbreviation { get; set; }
    }
}