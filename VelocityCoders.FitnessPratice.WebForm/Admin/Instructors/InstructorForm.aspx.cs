using System;
using System.Data;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.Instructors
{
    public partial class InstructorForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindInstructorNavigation();
                this.BindEmployeeType();

                this.CheckUpdate();
            }
        }

        //========  BIND EVENTS, BUTTONS   =============\\
        private void SetButtons(bool isUpdate)
        {
            bool isEmptyForm = CheckFormIsNull();

            if (isUpdate)
            {
                btnSave.Text = "Update Instructor";
                btnCancel.Visible = true;
                btnDelete.Visible = true;
                if (!isEmptyForm)
                {
                    btnSave.Enabled = true;
                }
            }
            else
            {
                btnSave.Text = "Add Instructor";
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                if (isEmptyForm)
                {
                    btnSave.Enabled = false;
                }
            }
        }

        private bool CheckFormIsNull()
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtBirthDate.Text != "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.DeleteInstructor();
        }

        private void DeleteInstructor()
        {
            int instructorId = hidInstructorId.Value.ToInt();

            if (instructorId > 0)
            {
                if (InstructorManager.Delete(instructorId))
                {
                    Response.Redirect("InstructorList.aspx");
                    base.DisplayPageMessage(lblPageMessage, "Record deleted successfully");
                }
                else
                    base.DisplayPageMessage(lblPageMessage, "Error. Delete failed.");
            }
            else
                base.DisplayPageMessage(lblPageMessage, "Invalid ID. Delete failed.");

        }

        private void CheckUpdate()
        {
            // int instructorId = Request.QueryString["InstructorId"].ToInt();
            if (base.InstructorId > 0)
            {
                Instructor instructorToUpdate = InstructorManager.GetItem(base.InstructorId);

                if (instructorToUpdate != null)
                {
                    this.BindUpdateInfo(instructorToUpdate);
                    this.SetButtons(true);
                }
                else
                {
                    this.SetButtons(false);
                }
            }
            else
            {
                this.SetButtons(false);
            }

        }

        private void BindInstructorNavigation()
        {
            #region IMPLEMENTATION FOR SETTING THE CURRENT PAGE FOR NAVIGATION MENU
            instructorNavigation.CurrentNavigationLink = InstructorNavigation.InstructorForm;
            instructorNavigation.InstructorId = base.InstructorId;
            #endregion
        }

        private void BindUpdateInfo(Instructor instructorToUpdate)
        {
            //====   POPULATE FORM DATA TO UPDATE   ===\\
            if (instructorToUpdate.FirstName != null)
                txtFirstName.Text = instructorToUpdate.FirstName;
            if (instructorToUpdate.DisplayFirstName != null)
                txtPreferredFirstName.Text = instructorToUpdate.DisplayFirstName;
            if (instructorToUpdate.LastName != null)
                txtLastName.Text = instructorToUpdate.LastName;
            if (instructorToUpdate.Description != null)
                txtNotes.Text = instructorToUpdate.Description;

            //====    DATA FIELDS
            if (instructorToUpdate.BirthDate != DateTime.MinValue)
                txtBirthDate.Text = instructorToUpdate.BirthDate.ToShortDateString();
            if (instructorToUpdate.HireDate != DateTime.MinValue)
                txtHireDate.Text = instructorToUpdate.HireDate.ToShortDateString();
            if (instructorToUpdate.TermDate != DateTime.MinValue)
                txtTermDate.Text = instructorToUpdate.TermDate.ToShortDateString();

            //====    DROP-DOWN
            if (instructorToUpdate.EntityTypeId > 0)
                drpEmployeeType.SelectedValue = instructorToUpdate.EntityTypeId.ToString();
            if (instructorToUpdate.Gender != null)
                drpGender.SelectedValue = instructorToUpdate.Gender;

            //====    HIDDEN FIELDS TO HOLD INSTRUCTOR ID AND PERSON ID
            hidInstructorId.Value = base.InstructorId.ToString();
            hidPersonId.Value = instructorToUpdate.PersonId.ToString();

            //====    UPDATE THE TEXT OF THE BUTTON
            btnSave.Text = "Update Instructor";

        }

        private void BindEmployeeType()
        {

            EntityTypeCollectionList bindEmployeeTypeDropDown = EntityTypeManager.GetCollection(EntityNames.EmployeeType, QuerySelectType.GetEntityType);

            drpEmployeeType.DataSource = bindEmployeeTypeDropDown;
            drpEmployeeType.DataBind();

            drpEmployeeType.Items.Insert(0, new ListItem { Text=" ( Select an employee type )", Value="0" });

        }


        #region ProcessForm METHOD | INVOKED WHEN CLICK_EVENT "Save_Click" is clicked
        protected void ProcessForm()
        {
            //====  CAPTURE VALUES FROM FRONT-END FORM
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
            #endregion


            #region BECAUSE INSTRUCTOR INHERITS FROM BASE PERSON CLASS, ITS MEMBERS ARE AVAILABLE TO THE INSTRUCTOR CLASS

            //=======  CREATING A NEW INSTANCE OBJECT OF INSTRUCTOR  ========\\
            Instructor instructorToSave = new Instructor();

            //=======  SETTING PERSONIS AND INSTRUCTORID PROPERTIES BASED ON QUERYID POSTBACK VALUE
            instructorToSave.InstructorId = hidInstructorId.Value.ToInt();
            instructorToSave.PersonId = hidPersonId.Value.ToInt();

            //=======  THESE ARE PROPERITES OF THE PERSON CLASS   ====\\
            instructorToSave.FirstName = firstName;
            instructorToSave.LastName = lastName;
            instructorToSave.DisplayFirstName = preferredFirstName;
            instructorToSave.BirthDate = birthDate.ToDate();
            instructorToSave.Gender = gender;

            //=======   THESE ARE PROPERTIES OF THE INSTRUCTOR CLASS   ====\\
            instructorToSave.HireDate = hireDate.ToDate();
            instructorToSave.TermDate = termDate.ToDate();
            instructorToSave.EntityTypeId = employeeType.ToInt();
            instructorToSave.Description = notes;

            InstructorManager.Save(instructorToSave);

            base.DisplayPageMessage(lblPageMessage, "Update was successful.");

            #endregion

        }

    }
}