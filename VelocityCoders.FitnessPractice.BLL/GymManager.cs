using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;



namespace VelocityCoders.FitnessPractice.BLL
{
    public static class GymManager
    {
        #region SECTION 1 ||=======  GET ITEM  =======||
        #region ||=======  GET ITEM | BY GYM-ID  =======||
        public static Gym GetItem(int gymId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (gymId <= 0)
            {
                saveBrokenRules.Add("Gym", "Invalid ID: " + gymId.ToString());
                throw new BLLException("There was an error retrieving Gym.", saveBrokenRules);
            }

            Gym item = GymDAL.GetItem(gymId);

            if (item == null)
            {
                saveBrokenRules.Add("Gym", "Could not retrieve record with ID: " + gymId.ToString());
                throw new BLLException("Error: No record found", saveBrokenRules);
            }
            else
            {
                return item;
            }
        }
        #endregion
        #endregion

        #region SECTION 2 ||=======  GET COLLECTION  =======||
        #region ||=======  GET COLLECTION | ALL =======||
        public static GymCollection GetCollection()
        {
            GymCollection collection = GymDAL.GetCollection();
            return collection;
        }
        #endregion
        #endregion

        #region SECTION 3 ||=======  INSERT OR UPDATE ITEM  =======||
        #region ||=======  INSERT OR UPDATE ITEM | BY GYM-ID  =======||
        public static int SaveItem(Gym gymObj)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(gymObj.GymName))
            {
                saveBrokenRules.Add("Gym Name", "Name is required");
            }

            if (saveBrokenRules.Count > 0)
            {
                throw new BLLException("There was an error saving Gym.", saveBrokenRules);
            }
            else
            {
                return GymDAL.SaveItem(gymObj);
            }

        }
        #endregion
        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||
        #region ||=======  DELETE ITEM | BY GYM-ID  =======||
        public static bool DeleteItem(int gymId)
        {
            if (gymId > 0)
                return GymDAL.DeleteItem(gymId);
            else
                throw new BLLException("Delete failed. Gym ID is invalid: " + gymId.ToString());
        }
        #endregion
        #endregion

    }
}
