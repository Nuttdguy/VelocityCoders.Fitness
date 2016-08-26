using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;

namespace VelocityCoders.FitnessPratice.WebForm
{
    public partial class PersonDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPerson();
        }

        private void BindPerson()
        {
            int personId = Request.QueryString["PersonId"].ToInt();

            if (personId > 0)
            {
                Person personLookup = PersonManager.GetPersonItem(personId);

                if (personLookup != null)
                {
                    lblPersonId.Text = personLookup.personId.ToString();
                    lblFirstName.Text = personLookup.firstName;
                    lblLastName.Text = personLookup.lastName;
                    lblDisplayName.Text = personLookup.displayFirstName;
                    lblBirthDate.Text = personLookup.BirthDate.ToLongTimeString();
                    lblGender.Text = personLookup.gender;
                }
                else
                    lblMessage.Text = "Person could not be found.";
            }
            else
                lblMessage.Text = "Invalid ID. Person record could not be found.";
        }

    }
}