using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;


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
            FitnessClassCollectionList FitClassList = new FitnessClassCollectionList();
            FitClassList = FitnessClassManager.GetFitnessClassCollection();

            repeaterText.DataSource = FitClassList;
            repeaterText.DataBind();
        }
    }
}