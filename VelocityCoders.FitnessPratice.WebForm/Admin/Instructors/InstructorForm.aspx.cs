using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using System.Text;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.Instructors
{
    public partial class InstructorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorNavigation();
            this.BindEmployeeType();
        }


        private void BindInstructorNavigation()
        {
            #region IMPLEMENTATION FOR SETTING THE CURRENT PAGE FOR NAVIGATION MENU
                instructorNavigation.CurrentNavigationLink = InstructorNavigation.InstructorForm;
                instructorNavigation.InstructorId = 1;
            #endregion
        }


        private void BindEmployeeType()
        {
            #region USE BUSINESS LOGIC LAYER TO RETRIEVE DATA USING METHODS OF THE DAL LAYER

            EntityTypeCollectionList bindEmployeeTypeDropDown = EntityTypeManager.GetCollection(EntityNames.EmployeeType, QuerySelectType.GetEntityType);

            drpEmployeeType.DataSource = bindEmployeeTypeDropDown;
            drpEmployeeType.DataBind();

            drpEmployeeType.Items.Insert(0, new ListItem { Text=" ( Select an employee type )", Value="0" });

            #endregion
        }


        protected void ProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string firstName = txtFirstName.Text;
            string preferredFirstName = txtPreferredFirstName.Text;
            string lastName = txtLastName.Text;
            string birthDate = txtBirthDate.Text;
            string hireDate = txtHireDate.Text;
            string termDate = txtTermDate.Text;
            string employeeType = drpEmployeeType.SelectedItem.Text;
            string gender = drpGender.SelectedItem.Text;
            string notes = txtNotes.Text;

            formValues.Append("First Name: " + firstName);
            formValues.Append("<br />");
            formValues.Append("Preferred First Name: " + preferredFirstName);
            formValues.Append("<br />");
            formValues.Append("Last Name: " + lastName);
            formValues.Append("<br />");
            formValues.Append("Birth Date: " + birthDate);
            formValues.Append("<br />");
            formValues.Append("Hire Date: " + hireDate);
            formValues.Append("<br />");
            formValues.Append("Term Date: " + termDate);
            formValues.Append("<br />");
            formValues.Append("Employee Type: " + employeeType);
            formValues.Append("<br />");
            formValues.Append("Gender: " + gender);
            formValues.Append("<br />");
            formValues.Append("Notes: " + notes);

            // lblPageMessage.Text = formValues.ToString();

        }

        #region PROCESS FORMS

        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }

        #endregion

    }
}