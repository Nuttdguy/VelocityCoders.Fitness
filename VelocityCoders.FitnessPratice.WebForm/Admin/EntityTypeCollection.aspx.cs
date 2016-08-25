using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class EntityTypeCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEntityType();
        }

        #region GET_ENTITYTYPE COLLECTION

        private void BindEntityType()
        {
            EntityTypeCollectionList bindObject = new EntityTypeCollectionList();
            bindObject = EntityTypeDAL.GetCollection();

            repeaterText.DataSource = bindObject;
            repeaterText.DataBind();
        }
        #endregion
    }
}