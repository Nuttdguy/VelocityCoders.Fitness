using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;

namespace VelocityCoders.FitnessPratice.WebForm
{
    public partial class FitnessPractice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPersonList();
            // label0.Text = AddInstructor();
        }

        private void BindPersonList()
        {
            PersonCollection personList = new PersonCollection();
            personList = PersonDAL.GetCollection();

            repeaterText.DataSource = personList;
            repeaterText.DataBind();
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