using System;
using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class EntityTypeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEntity();
        }

        private void BindEntity()
        {
            int myItem = Request.QueryString["EntityTypeId"].ToInt();

            if (myItem > 0 )
            {
                EntityType myItemLookup = EntityTypeDAL.GetItem(myItem);
                if(myItemLookup != null)
                {
                    lblEntityTypeId.Text = myItemLookup.EntityId.ToString();
                    lblEntityType.Text = myItemLookup.EntityId.ToString();
                    lblEntityType.Text = myItemLookup.Description;
                    lblDisplayName.Text = myItemLookup.DisplayName;
                    lblEntityTypeName.Text = myItemLookup.EntityTypeName;
                }
            }
        }
    }
}