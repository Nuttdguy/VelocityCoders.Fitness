using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class EmailAddressManager
    {


        public static int Save(int instructorId, EmailAddress emailToSave)
        {
            return EmailAddressDAL.Save(instructorId, emailToSave);
        }

        public static bool Delete(int emailId)
        {
            return EmailAddressDAL.Delete(emailId);
        }


        public static EmailAddressCollection GetCollection(int instructorId)
        {
            return EmailAddressDAL.GetCollection(instructorId);
        }


        public static EmailAddress GetItemByEmailId(int emailId)
        {
            return EmailAddressDAL.GetItem(emailId);
        }

    }
}
