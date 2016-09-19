using System;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.UserControls
{
    public partial class LookupTableNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCurrentNavigation();
                BindNavigationDropDown();
            }

        }


        public LookupTableNavigation CurrentNavigationLink { get; set; }

        #region ||=======  BIND CURRENT NAVIGATION  =======||
        private void BindCurrentNavigation()
        {
            if (CurrentNavigationLink !=  LookupTableNavigation.None)
            {
                drpSelectLookupTable.SelectedValue = CurrentNavigationLink.ToString();
            }
        }
        #endregion

        #region ||=======  BIND NAVIGATION DROP DOWN  =======||
        private void BindNavigationDropDown()
        {

            string configItems = Utilities.GetApplicationKeyValue("LookupTableNavigationItems");

            if (string.IsNullOrEmpty(configItems))
            {
                drpSelectLookupTable.Items.Add("Not Available");
            }
            else
            {
                string[] navItems = configItems.Split(',');

                ListItemCollection collection = new ListItemCollection();

                foreach (string item in navItems)
                    collection.Add(new ListItem { Text = item, Value = item.Replace(" ", "") });

                drpSelectLookupTable.DataSource = collection;
                drpSelectLookupTable.DataBind();

                if (CurrentNavigationLink != LookupTableNavigation.None)
                    drpSelectLookupTable.Items.Insert(0, new ListItem { Text = "(Select Lookup Table)", Value = "0" });
            }
        }
        #endregion

        #region ||=======  LOOKUP TABLE SELECTED | REDIRECT  =======||
        protected void LookupTables_Selected(object sender, EventArgs e)
        {
            if (drpSelectLookupTable.SelectedValue != "0")
            {
                Response.Redirect(drpSelectLookupTable.SelectedValue + "Lookup.aspx");
            }
        }
        #endregion

    }
}