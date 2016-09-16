using System;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMasterPageNavigation(MasterNavigation.LookupTables);
        }
    }
}