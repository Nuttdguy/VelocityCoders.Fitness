using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class EmailDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEmail();
        }

        private void BindEmail()
        {
            int myEmailId = Request.QueryString["EmailId"].ToInt();

            if (myEmailId > 0 )
            {
                Email myObject = EmailDAL.GetItem(myEmailId);
                if(myObject != null)
                {

                    lblEmailId.Text = myObject.EmailId.ToString();
                    lblEntityTypeId.Text = myObject.EntityTypeId.ToString();
                    lblInstructorId.Text = myObject.InstructorId.ToString();
                    lblEmailAddress.Text = myObject.EmailAddress;
                    lblDescription.Text = myObject.Description;

                }
            }
        }

    }
}