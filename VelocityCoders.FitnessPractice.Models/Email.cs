using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class Email : BaseCollection<Email>
    {
        public int EmailId { get; set; }
        public int EntityTypeId { get; set; }
        public int InstructorId { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }

    }
}
