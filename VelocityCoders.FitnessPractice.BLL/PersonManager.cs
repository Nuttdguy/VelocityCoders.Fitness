using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class PersonManager
    {
        #region DELETE RECORD FROM TABLE
        public static bool Delete(int personId)
        {
            return PersonDAL.Delete(personId);
        }

        #endregion

        #region INSERT AND\OR UPDATE RECORD | RETURN ID RESULT
        public static int Save(Person personToSave)
        {
            int returnValue;
            returnValue = PersonDAL.Save(personToSave);

            return returnValue;
        }

        #endregion

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
