using System;


namespace VelocityCoders.FitnessPractice.Models
{
    public class Instructor : Person
    {

        //================   PROPERTIES   ====================\\

        public int InstructorId { get; set; }
        //public int PersonId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TermDate { get; set; }
        public DateTime CreateDate { get; set; }
        //public string Description { get; set; }
        public int EntityTypeId { get; set; }

        //================   METHODS   ====================\\

        public string GetFullInfo()
        {
            return "Hello";
        }

        public EmailAddressCollection Emails { get; set; }

        public Instructor()
        {
            this.Emails = new EmailAddressCollection();
        }
    }

}
