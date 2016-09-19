using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMasterPageNavigation(MasterNavigation.LookupTables);
            //BindNavigation();

        }


        #region ||=======  BIND NAVIGATION  =======||
        private void BindNavigation()
        {
            lookupTablesNavigation.CurrentNavigationLink = LookupTableNavigation.Test;
        }


        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity testObj = new Entity();

            int entityId = txtEntityId.Text.ToInt();
            string entityName = txtEntityName.Text;

            testObj.EntityId = entityId;
            testObj.EntityName = entityName;

            EntityManager.Save(entityId, testObj);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            int entityId = txtEntityId.Text.ToInt();

            EntityManager.Delete(entityId);
        }

    }
}