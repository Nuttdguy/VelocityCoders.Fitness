using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{

    [DataContract(Name = "EntityTypeDTO")]
    public class EntityTypeDTO
    {

        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public int EntityTypeId { get; set; }

        [DataMember]
        public string EntityTypeName { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

    }
}
