using System;
using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.Models;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class InstructorManager
    {

        #region RETRIEVE SINGLE ITEM
        public static InstructorCollectionList GetInstructorItem(int instructorId)
        {
            return new InstructorCollectionList { };
        }
        #endregion


        #region RETRIEVE COLLECTION OF ITEMS
        public static InstructorCollectionList GetInstructorCollection()
        {
            InstructorCollectionList myList = InstructorDAL.GetCollection();
            return myList;
        }

        #endregion

    }
}
