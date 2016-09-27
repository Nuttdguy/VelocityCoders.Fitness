using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.Services.DataContracts;
using VelocityCoders.FitnessPractice.Services.ServiceContracts;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
using System.Net;
using System;

namespace VelocityCoders.FitnessPractice.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LocationService : ILocationService
    {

        #region SECTION 4 ||=======  GET ITEM  =======||

        #region ||=======  GET GYM LOCATION ITEM | BY GYM-ID  =======||
        public LocationDTO GetItem(string GymId)
        {
            Location tmpItem = LocationManager.GetItem(GymId.ToInt());
            return LocationToDTO(tmpItem);
        }
        #endregion

        #endregion

        #region SECTION 4 ||=======  GET COLLECTION  =======||

        #region ||=======  GET GYM LOCATION COLLECTION | ALL  =======||
        public LocationDTOCollection GetCollection()
        {
            LocationCollection tmpCollection = LocationManager.GetCollection();
            return LocationCollectionToDTO(tmpCollection);
        }
        #endregion

        #endregion

        #region SECTION 4 ||=======  SAVE  =======||

        #region ||=======  SAVE GYM LOCATION  =======||
        public LocationDTO SaveItem(LocationDTO locationDTO)
        {
            int gymId = LocationManager.SaveItem(DTOToLocation(locationDTO));
            Location tmpItem = LocationManager.GetItem(gymId);
            return LocationToDTO(tmpItem);
        }
        #endregion

        #endregion

        #region SECTION 4 ||=======  DELETE  =======||

        #region ||=======  DELETE GYM LOCATION | BY LOCATION-ID  =======||
        public int DeleteItem(string locationId)
        {
            return LocationManager.DeleteItem(locationId.ToInt());  
        }
        #endregion

        #endregion


        #region SECTION 5 ||=======  HYDRATE OBJECT  =======||

        #region ||=======  LOCATION-DTO TO LOCATION-ITEM | INCOMING  =======||
        private Location DTOToLocation(LocationDTO locationDTO)
        {
            Location tmpObj = new Location();

            tmpObj.LocationId = locationDTO.LocationId;
            tmpObj.Gym.GymId = locationDTO.GymDTO.GymId;
            tmpObj.LocationName = locationDTO.LocationName;
            tmpObj.State.StateId = locationDTO.StateDTO.StateId;
            tmpObj.Address01 = locationDTO.Address01;
            tmpObj.Address02 = locationDTO.Address02;
            tmpObj.City = locationDTO.City;
            tmpObj.ZipCode = locationDTO.ZipCode;
            tmpObj.ZipCodePlusFour = locationDTO.ZipCodePlusFour;

            return tmpObj;
        }
        #endregion

        #region ||=======  LOCATION-ITEM TO DTO | OUTGOING  =======||
        private LocationDTO LocationToDTO(Location location)
        {
            LocationDTO tmpObj = new LocationDTO();

            tmpObj.LocationId = location.LocationId;
            tmpObj.GymDTO.GymId = location.Gym.GymId;
            tmpObj.StateDTO.StateId = location.State.StateId;
            tmpObj.LocationName = location.LocationName;
            tmpObj.Address01 = location.Address01;
            tmpObj.Address02 = location.Address02;
            tmpObj.City = location.City;
            tmpObj.ZipCode = location.ZipCode;
            tmpObj.ZipCodePlusFour = location.ZipCodePlusFour;

            return tmpObj;
        }
        #endregion

        #region ||=======  LOCATION-COLLECTION TO DTO | OUTGOING  =======||
        private LocationDTOCollection LocationCollectionToDTO(LocationCollection locationCollection)
        {
            LocationDTOCollection tmpCollection = new LocationDTOCollection();

            if (locationCollection != null)
            {
                foreach (Location item in locationCollection)
                {
                    tmpCollection.Add(LocationToDTO(item));
                }
            }

            return tmpCollection;
        }

        #endregion

        #endregion

        #region SECTION 6 ||=======  ID HELPER METHOD  ======||


        #endregion
    }
}