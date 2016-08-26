using System;
using System.Collections.Generic;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class PersonManager
    {
        #region GET-ITEM 
        public static PersonCollectionList GetPersonItem(int personId)
        {
            return new PersonCollectionList();

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
