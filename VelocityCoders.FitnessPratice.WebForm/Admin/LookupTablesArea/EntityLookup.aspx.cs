using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea
{
    public partial class EntityLookup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindNavigation();
        }

        private void BindNavigation()
        {
            lookupTablesNavigation.CurrentNavigationLink = LookupTableNavigation.Entity;
        }
    }
}