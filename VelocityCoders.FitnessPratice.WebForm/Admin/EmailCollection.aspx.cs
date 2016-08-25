using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class EmailCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEmailData();
        }

        public void BindEmailData()
        {
            EmailCollectionList myEmailList = new EmailCollectionList();
            myEmailList = EmailDAL.GetCollection();

            repeaterText.DataSource = myEmailList;
            repeaterText.DataBind();
        }
    }
}