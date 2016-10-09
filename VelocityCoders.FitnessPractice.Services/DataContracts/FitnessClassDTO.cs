using System.ServiceModel;
using System.Runtime.Serialization;


namespace VelocityCoders.FitnessPractice.Services.DataContracts
{
    [DataContract(Name = "FitnessClassDTO")]
    public class FitnessClassDTO
    {
        [DataMember]
        public int FitnessClassId { get; set; }

        [DataMember]
        public string FitnessClassName { get; set; }

        [DataMember]
        public string Description { get; set; }

        //[DataMember]
        //public int InstructorFitnessClassId { get; set; }

    }
}