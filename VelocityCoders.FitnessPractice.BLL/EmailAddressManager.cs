using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPractice.BLL
{
    public static class EmailAddressManager
    {


        public static int Save(int instructorId, EmailAddress emailToSave)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (instructorId <= 0)
                saveBrokenRules.Add("Instructor", "Invalid ID.");

            ValidateEmail(emailToSave, ref saveBrokenRules);

            if (emailToSave.EmailType.EntityTypeId <= 0)
            {
                saveBrokenRules.Add("Email Address Type", "Type is required.");
            }

            if (saveBrokenRules.Count > 0)
            {
                throw new BLLException("There was an error saving Email.", saveBrokenRules);
            }
            else
            {
                return EmailAddressDAL.Save(instructorId, emailToSave);
            }

        }


        public static bool Delete(int emailId)
        {
            if (emailId > 0)
                return EmailAddressDAL.Delete(emailId);
            else
                throw new BLLException("Delete failed. Email ID is invalid: " + emailId.ToString());
        }


        public static EmailAddressCollection GetCollection(int instructorId)
        {
            return EmailAddressDAL.GetCollection(instructorId);
        }


        public static EmailAddress GetItemByEmailId(int emailId)
        {
            return EmailAddressDAL.GetItem(emailId);
        }

        //==  EMAIL ADDRESS VALIDATION  ==\\
        private static bool ValidateEmail(EmailAddress emailToValidate, ref BrokenRuleCollection brokenRules)
        {
            bool returnValue = true;

            if (emailToValidate != null)
            {
                if (!string.IsNullOrEmpty(emailToValidate.EmailValue))
                {
                    if (!EmailValidator.IsValid(emailToValidate.EmailValue.Trim()))
                    {
                        brokenRules.Add("Email Address", emailToValidate.EmailValue.Trim() + " is an invalid email format.");
                        returnValue = false;
                    }
                }
                else
                {
                    brokenRules.Add("Email Address", "Email is required");
                    returnValue = false;
                }
            }
            else
            {
                brokenRules.Add("Email Address", "Email class was not instantiated.");
                returnValue = false;
            }

            return returnValue;
        }

    }
}
