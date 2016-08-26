using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class PersonManager
    {
        #region GET-ITEM 
        public static Person GetPersonItem(int personId)
        {

            Person myItem = PersonDAL.GetItem(personId);
            return myItem;

        }
        #endregion


        #region GET-COLLECTION
        public static PersonCollectionList GetPersonCollection()
        {
            PersonCollectionList myPersonList = PersonDAL.GetCollection();
            return myPersonList;
        }
        #endregion

    }
}
