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
            return GymDAL.GetItem(gymId);
        }
        #endregion
        #endregion

        #region SECTION 2 ||=======  GET COLLECTION  =======||
        #region ||=======  GET COLLECTION | ALL =======||
        public static GymCollection GetCollection()
        {
            return GymDAL.GetCollection();
        }
        #endregion
        #endregion

        #region SECTION 3 ||=======  INSERT OR UPDATE ITEM  =======||
        #region ||=======  INSERT OR UPDATE ITEM | BY GYM-ID  =======||
        public static int SaveItem(int gymId, Gym gymObj)
        {
            return GymDAL.SaveItem(gymId, gymObj);
        }
        #endregion
        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||
        #region ||=======  DELETE ITEM | BY GYM-ID  =======||
        public static int DeleteItem(int gymId)
        {
            return GymDAL.DeleteItem(gymId);
        }
        #endregion
        #endregion

    }
}
