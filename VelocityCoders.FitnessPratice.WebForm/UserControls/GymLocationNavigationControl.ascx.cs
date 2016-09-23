using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.UserControls
{
    public partial class GymLocationNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCurrentNavigation();
                BindNavigationDropDown();
            }
        }

        #region SECTION 1 ||=======  PROPERTIES  =======||
        public GymLocationNavigation CurrentNavigationLink { get; set; }
        #endregion

        #region SECTION 2 ||=======  BIND CONTROLS  =======||
        private void BindNavigationDropDown()
        {
            string configItems = Utilities.GetApplicationKeyValue("GymLocationNavigationItems");

            if (string.IsNullOrEmpty(configItems))
            {
                drpSelectGymLocation.Items.Add("Not Available");
            }
            else
            {
                string[] navItems = configItems.Split(',');

                ListItemCollection collection = new ListItemCollection();

                foreach (string item in navItems)
                    collection.Add(new ListItem { Text = item, Value = item.Replace(" ", "") });

                drpSelectGymLocation.DataSource = collection;
                drpSelectGymLocation.DataBind();

                if (CurrentNavigationLink == GymLocationNavigation.None)
                    drpSelectGymLocation.Items.Insert(0, new ListItem { Text = "(Select Section)", Value = "0" });
            }
        }
        #endregion

        #region SECTION 3 ||=======  EVENT HANDLER  =======||
        private void BindCurrentNavigation()
        {
            if (CurrentNavigationLink != GymLocationNavigation.None)
            {
                drpSelectGymLocation.SelectedValue = CurrentNavigationLink.ToString();
            }

        }

        protected void GymLocation_Selected(object sender, EventArgs e)
        {
            if (drpSelectGymLocation.SelectedValue != "0")
            {
                Response.Redirect(drpSelectGymLocation.SelectedValue + "Manage.aspx");
            }
        }

        #endregion

    }
}