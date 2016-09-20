using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class LocationManager
    {
        #region SECTION 1 ||=======  GET ITEM  =======||
        #region ||=======  GET ITEM | BY LOCATION-ID  =======||
        public static Location GetItem(int stateId)
        {
            return LocationDAL.GetItem(stateId);
        }
        #endregion
        #endregion

        #region SECTION 2 ||=======  GET COLLECTION  =======||
        #region ||=======  GET COLLECTION | ALL =======||
        public static LocationCollection GetCollection()
        {
            return LocationDAL.GetCollection();
        }
        #endregion
        #endregion

        #region SECTION 3 ||=======  INSERT OR UPDATE ITEM  =======||
        #region ||=======  INSERT OR UPDATE ITEM | BY LOCATION-ID  =======||
        public static int SaveItem(int locationId, Location locationObj)
        {
            return LocationDAL.SaveItem(locationId, locationObj);
        }
        #endregion
        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||
        #region ||=======  DELETE ITEM | BY LOCATION-ID  =======||
        public static int DeleteItem(int locationId)
        {
            return LocationDAL.DeleteItem(locationId);
        }
        #endregion
        #endregion
    }
}
