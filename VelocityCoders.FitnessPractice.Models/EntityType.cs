using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.Models
{
    public class EntityType : BaseCollection<EntityType>
    {
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string EntityTypeName { get; set; }

    }
}
