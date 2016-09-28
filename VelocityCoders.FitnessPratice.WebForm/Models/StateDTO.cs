using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace VelocityCoders.FitnessPratice.WebForm.Models
{
    public class StateDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string ShortName { get; set; }
        public string StateAbbreviation { get; set; }

        #region SECTION 1 ||=======  JSON SERIALIZATION  =======||

        public T GetStateDTO<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T StateItem = serializer.Deserialize<T>(json);

            return StateItem;
        }

        public List<T> GetStateCollection<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<T> StateCollection = serializer.Deserialize<List<T>>(json);

            return StateCollection;
        }

        #endregion

    }
}