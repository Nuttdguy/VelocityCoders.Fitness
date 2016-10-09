using System;
using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.Models;



namespace VelocityCoders.FitnessPractice.BLL
{
    public class FitnessClassManager
    {

        #region GET-ITEM
        public static FitnessClass GetFitnessClassItem(int fitnessClassId)
        {
            FitnessClass MyFitnessClassItem = FitnessClassDAL.GetItem(fitnessClassId);
            return MyFitnessClassItem;
        }
        #endregion

        #region GET-COLLECTION
        public static FitnessClassCollectionList GetFitnessClassCollection()
        {
            FitnessClassCollectionList myCollection = FitnessClassDAL.GetCollection();
            return myCollection;
        }

        public static FitnessClassCollectionList GetFitnessClassCollection(int instructId)
        {
            FitnessClassCollectionList myCollection = FitnessClassDAL.GetCollectionbyId(instructId);
            return myCollection;
        }

        #endregion

        #region SECTION 3 ||=======  SAVE OR UPDATE ITEM  =======||  
        public static int SaveItem(FitnessClass fcItem)
        {
            int recordId = FitnessClassDAL.SaveItem(fcItem);
            return recordId;
        }


        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||
        public static int DeleteItem(int fcId)
        {
            int recordId = FitnessClassDAL.DeleteItem(fcId);
            return recordId;
        }


        #endregion

        #region SECTION 5 ||=======  ADD FITNESS CLASS  =======||  
        public static int AddFitnessClass(FitnessClass fcItem)
        {
            int recordId = FitnessClassDAL.SaveItem(fcItem);
            return recordId;
        }


        #endregion

    }
}
