using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{
    [DataContract(Name = "LocationDTO")]
    public class LocationDTO
    {
        [DataMember]
        public int LocationId { get; set; }

        [DataMember]
        public GymDTO GymDTO { get; set; }

        [DataMember]
        public StateDTO StateDTO { get; set; }

        [DataMember]
        public string LocationName { get; set; }

        [DataMember]
        public string Address01 { get; set; }

        [DataMember]
        public string Address02 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string ZipCodePlusFour { get; set; }

        public LocationDTO()
        {
            this.GymDTO = new GymDTO();
            this.StateDTO = new StateDTO();
        }

    }

}