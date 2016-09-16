using System;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.MasterPages
{
    public partial class Site2Column : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMasterNavigation();
        }

        public MasterNavigation SelectedMasterPageNavigation { get; set; }

        private void BindMasterNavigation()
        {
            switch(SelectedMasterPageNavigation)
            {
                case MasterNavigation.Instructor:
                    Instructor.Attributes.Add("class", "Selected");
                    break;
                case MasterNavigation.GymLocation:
                    GymLocation.Attributes.Add("class", "Selected");
                    break;
                case MasterNavigation.FitnessClass:
                    FitnessClass.Attributes.Add("class", "Selected");
                    break;
                case MasterNavigation.Schedule:
                    Schedule.Attributes.Add("class", "Selected");
                    break;
                case MasterNavigation.LookupTables:
                    LookupTables.Attributes.Add("class", "Selected");
                    break;
            }
        }

    }
}