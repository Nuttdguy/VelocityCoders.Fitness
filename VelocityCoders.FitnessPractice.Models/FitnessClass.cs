using System;


namespace VelocityCoders.FitnessPractice.Models
{
    public class FitnessClass : BaseCollection<FitnessClass>
    {
        public int FitnessClassId { get; set; }
        public string FitnessClassName { get; set; }
        public string Description { get; set; }
    }
}
