using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessPractice.Services.Faults
{

    [DataContract(Name = "EntityLookupServiceFault")]
    public class EntityLookupServiceFault
    {

        [DataMember]
        public string ErrorMessage { get; set; }

        #region CONSTRUCTOR

        public EntityLookupServiceFault(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        #endregion
    }
}