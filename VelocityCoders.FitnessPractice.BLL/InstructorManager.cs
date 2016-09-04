using System;
using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.Models;


namespace VelocityCoders.FitnessPractice.BLL
{
    public static class InstructorManager
    {
        #region DELETE RECORD FROM TABLE
        public static bool Delete(int instructorId)
        {
            Instructor toDelete = InstructorManager.GetItem(instructorId);
            if (toDelete != null)
            {
                if (toDelete.PersonId > 0 && toDelete.InstructorId > 0)
                {

                    if (InstructorDAL.Delete(toDelete.InstructorId))
                    {
                        return PersonDAL.Delete(toDelete.PersonId);
                    }
                    else
                        return false;
                }
                else return false;
            }
            else return false;
        }

        #endregion

        #region INSERT/UPDATE RECORD | RETURN INT VALUE OF AFFECTED RECORD
        public static int Save(Instructor instructorToSave)
        {
            int personId = SavePerson(instructorToSave);
            instructorToSave.PersonId = personId;

            return InstructorDAL.Save(instructorToSave);
        }

        //== UPDATE 
        public static int SaveEmail(int instructorId, EmailAddress emailToSave)
        {
            return EmailAddressManager.Save(instructorId, emailToSave);
        }

        #endregion



        #region PRIVATE METHOD | CREATE A NEW INSTANCE OF 
        private static int SavePerson(Instructor instructorToSave)
        {
            Person tempPerson = new Person();

            tempPerson.PersonId = instructorToSave.PersonId;

            tempPerson.FirstName = instructorToSave.FirstName;
            tempPerson.LastName = instructorToSave.LastName;
            tempPerson.DisplayFirstName = instructorToSave.DisplayFirstName;
            tempPerson.BirthDate = instructorToSave.BirthDate;
            tempPerson.Gender = instructorToSave.Gender;

            return PersonManager.Save(tempPerson);
        }

        #endregion

        #region RETRIEVE SINGLE ITEM
        public static Instructor GetInstructorItem(int instructorId)
        {
            Instructor myInstructor = InstructorDAL.GetItem(instructorId);
            return myInstructor;
        }
        #endregion

        #region RETRIEVE COLLECTION OF ITEMS | INSTRUCTOR ENTITY ONLY
        public static InstructorCollectionList GetInstructorCollection()
        {

            return InstructorDAL.GetCollection();
        }

        #endregion

        #region RETRIEVE COLLECTION OF ITEMS | INSTRUCTOR LIST
        public static InstructorCollectionList GetInstructorCollection(QuerySelectType queryId)
        {
            // InstructorCollectionList myList = InstructorDAL.GetCollection();
            return InstructorDAL.GetCollection(queryId); 
        }

        #endregion

        #region GET A SINGLE RECORD | INSTRUCTOR AND PERSON
        public static Instructor GetItem(int instructorId)
        {
            return InstructorDAL.GetItem(instructorId);
        }

        #endregion


    }
}
