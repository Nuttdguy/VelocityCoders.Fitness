using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class EmailAddress
    {
        public int EmailId { get; set; }
        public string EmailValue { get; set; }
        public EntityType EmailType { get; set; }

        public EmailAddress() { this.EmailType = new EntityType(); }

        public EmailAddress(int entityTypeId, string emailAddress)
        {
            this.EmailType = new EntityType { EntityTypeId = entityTypeId };
            this.EmailValue = emailAddress;
        }

    }
}
