using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class FitnessClassCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindFitnessClass();
        }

        private void BindFitnessClass()
        {
            FitnessClass fitClassList = new FitnessClass();
            //fitClassList = FitnessClassDAL;
            fitClassList = VelocityCoders.FitnessPractice.DAL.FitnessClassDAL.GetCollection();

            repeaterText.DataSource = fitClassList;
            repeaterText.DataBind();
        }
    }
}