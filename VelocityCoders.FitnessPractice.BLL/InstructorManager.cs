using System;
using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.Models;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class InstructorManager
    {

        #region RETRIEVE SINGLE ITEM
        public static Instructor GetInstructorItem(int instructorId)
        {
            Instructor myInstructor = InstructorDAL.GetItem(instructorId);
            return myInstructor;
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
