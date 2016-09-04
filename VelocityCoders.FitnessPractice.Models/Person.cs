using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class Person 
    {

        //=============  PROPERTIES  ===================\\
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayFirstName { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }


        //=============  CONSTRUCTORS  ===================\\
        public Person() { }

        public Person(string firstName, string lastName)
        {

        }

        public Person(string firstName, string lastName, string gender)
        {

        }

        //=============  METHODDS  ===================\\

        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        public string FullNameLastNameFirst
        {
            get { return this.LastName + " " + this.FirstName;  }
        }

    }
}
