using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessPratice.WebForm.Models
{
    public class LocationDTO
    {
        public int LocationId { get; set; }
        public GymDTO GymDTO { get; set; }
        public StateDTO StateDTO { get; set; }
        public string LocationName { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string ZipCodePlusFour { get; set; }

        public LocationDTO()
        {
            this.StateDTO = new StateDTO();
            this.GymDTO = new GymDTO();
        }

        #region SECTION 1 ||=======  JSON SERIALIZATION  =======||

        public T GetLocationName<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T LocationItem = serializer.Deserialize<T>(json);

            return LocationItem;
        }

        public List<T> GetLocationCollection<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<T> LocationList = serializer.Deserialize<List<T>>(json);

            return LocationList;
        }

        #endregion

    }
}