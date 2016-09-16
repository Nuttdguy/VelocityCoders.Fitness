using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessPractice.Services.DataContracts
{

    [CollectionDataContract(Name = "EntityDTOCollection")]
    public class EntityDTOCollection : Collection<EntityDTO> { };

    [CollectionDataContract(Name = "EntityTypeDTOCollection")]
    public class EntityTypeDTOCollection : Collection<EntityTypeDTO> { };

}