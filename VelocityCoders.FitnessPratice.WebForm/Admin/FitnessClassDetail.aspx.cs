using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class FitnessClassDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindFitnessClassItem();
        }

        private void BindFitnessClassItem()
        {
            int fitnessClassId = Request.QueryString["FitnessClassId"].ToInt();

            if (fitnessClassId > 0 )
            {
                FitnessClass fitnessClassLookup = FitnessClassDAL.GetItem(fitnessClassId);
                if (fitnessClassLookup != null)
                {
                    lblFitnessClassId.Text = fitnessClassLookup.FitnessClassId.ToString();
                    lblFitnessClassName.Text = fitnessClassLookup.FitnessClassName;
                    lblDescription.Text = fitnessClassLookup.Description;
                }
            }

        }

    }
}