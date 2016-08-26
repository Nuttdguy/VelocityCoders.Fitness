using System;
using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.Models;



namespace VelocityCoders.FitnessPractice.BLL
{
    public class FitnessClassManager
    {

        #region GET-ITEM
        public static FitnessClassCollectionList GetFitnessClassItem(int fitnessClassId)
        {
            return new FitnessClassCollectionList { };
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
