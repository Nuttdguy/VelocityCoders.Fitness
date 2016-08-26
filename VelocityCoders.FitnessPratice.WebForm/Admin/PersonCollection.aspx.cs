using System;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPratice.WebForm
{
    public partial class PersonCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPersonList();
        }

        private void BindPersonList()
        {

            PersonCollectionList personList = PersonManager.GetPersonCollection();

            if (personList != null)
            {
                repeaterText.DataSource = personList;
                repeaterText.DataBind();
            }
            else
            {
                lblMessage.Text = "No available persons to display.";
            }
        }

        #region FOR DEMONSTRATION OF INTERFACE INHERITANCE
        //private string AddInstructor()
        //{
        //    Instructor Instructor01 = new Instructor();
        //    Instructor01.Detail = "This is an implementation test";
        //    string implement = Instructor01.AddDetail();
        //    return Instructor01.Detail + " == " + implement;
        //}
        #endregion
    }
}