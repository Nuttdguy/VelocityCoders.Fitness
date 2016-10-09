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

    [CollectionDataContract(Name = "GymDTOCollection")]
    public class GymDTOCollection : Collection<GymDTO> { };

    [CollectionDataContract(Name = "LocationDTOCollection")]
    public class LocationDTOCollection : Collection<LocationDTO> { };

    [CollectionDataContract(Name = "StateDTOCollection")]
    public class StateDTOCollection : Collection<StateDTO> { };

    [CollectionDataContract(Name = "FitnessClassDTOCollection")]
    public class FitnessClassDTOCollection : Collection<FitnessClassDTO> { };

    [CollectionDataContract(Name = "InstructorDTOCollection")]
    public class InstructorDTOCollection : Collection<InstructorDTO> { };
}