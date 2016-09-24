using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class LocationManager
    {
        #region SECTION 1 ||=======  GET ITEM  =======||
        #region ||=======  GET ITEM | BY LOCATION-ID  =======||
        public static Location GetItem(int locationId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (locationId <= 0)
            {
                saveBrokenRules.Add("Error", "Invalid ID: " + locationId.ToString());
                throw new BLLException("There was an error", saveBrokenRules);
            }

            Location item = LocationDAL.GetItem(locationId);

            if (item == null)
            {
                saveBrokenRules.Add("Error", "Nothing was returned ");
                throw new BLLException("There was an error", saveBrokenRules);
            }

            return item;

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
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (locationId <= 0)
            {
                saveBrokenRules.Add("Error", "Invalid ID: " + locationId);
                throw new BLLException("Error", saveBrokenRules);
            }

            int item = LocationDAL.SaveItem(locationId, locationObj);

            if (item < 0)
            {
                saveBrokenRules.Add("Error", "Save was unsuccessful" + locationId);
                throw new BLLException("Error", saveBrokenRules);
            }
            else
            {
                return item;
            }
        }
        #endregion

        #region ||=======  INSERT OR UPDATE ITEM | BY LOCATION-ID  =======||
        public static int SaveItem(Location locationObj)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();


            int item = LocationDAL.SaveItem(locationObj);

            if (item < 0)
            {
                saveBrokenRules.Add("Error", "Save was unsuccessful");
                throw new BLLException("Error", saveBrokenRules);
            }
            else
            {
                return item;
            }
        }
        #endregion
        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||
        #region ||=======  DELETE ITEM | BY LOCATION-ID  =======||
        public static int DeleteItem(int locationId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (locationId <= 0)
            {
                saveBrokenRules.Add("Error", "Invalid ID: " + locationId + " nothing to delete. ");
                throw new BLLException("Error", saveBrokenRules);
            }
            else
            {
                return LocationDAL.DeleteItem(locationId);
            }

        }
        #endregion
        #endregion
    }
}
