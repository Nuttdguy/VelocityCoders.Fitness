using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{
    [DataContract(Name = "EntityDTO")]
    public class EntityDTO
    {
        
        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public string EntityName { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

    }
}
