using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace VelocityCoders.FitnessPratice.WebForm.Models
{
    public class GymDTO
    {
        public int GymId { get; set; }
        public string GymName { get; set; }
        public string GymAbbreviation { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

        #region JSON SERIALIZATION 

        public T GetGymName<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T GymItem = serializer.Deserialize<T>(json);

            return GymItem;
        }

        public List<T> GetGymCollection<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<T> GymList = serializer.Deserialize<List<T>>(json);

            return GymList;
        }

        #endregion
    }
}