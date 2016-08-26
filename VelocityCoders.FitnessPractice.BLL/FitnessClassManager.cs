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

        #endregion


    }
}
