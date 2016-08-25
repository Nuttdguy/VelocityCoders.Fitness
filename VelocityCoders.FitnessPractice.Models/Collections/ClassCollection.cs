using System;
using System.Collections.Generic;

namespace VelocityCoders.FitnessPractice.Models
{

    //=============================================================================\\
    //   CLASSES THAT REQUIRE BASECOLLECTION AND ITS COLLECTION CLASS/INTERFACES   ||
    //=============================================================================//
    public class PersonCollection : BaseCollection<Person>
    {

    }

    public class InstructorCollection : BaseCollection<Instructor>
    {

    }

    public class FitnessClassCollection : BaseCollection<FitnessClass>
    {

    }

    public class EntityTypeCollection : BaseCollection<EntityType>
    {

    }

    public class EntityCollection : BaseCollection<Entity>
    {

    }

    public class EmailCollection : BaseCollection<Email>
    {

    }

}
