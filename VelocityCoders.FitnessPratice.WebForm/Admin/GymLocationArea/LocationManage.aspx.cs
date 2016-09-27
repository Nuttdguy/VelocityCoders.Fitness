using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.GymLocationArea
{
    public partial class LocationManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindNavigation();
                BindGymNames();
                BindDrpStateName();
            }
        }

        #region SECTION 1 ||=======  PROCESS  =======||

        #region ||=======  PROCESS FORM  =======||
        protected void ProcessForm()
        {
            Location locationItem = new Location();

            locationItem.Gym.GymId = drpGymName.SelectedValue.ToInt();
            locationItem.LocationName = txtLocationName.Text;
            locationItem.Address01 = txtAddress01.Text;
            locationItem.Address02 = txtAddress02.Text;
            locationItem.City = txtCity.Text;
            locationItem.State.StateId = drpStateName.SelectedValue.ToInt();
            locationItem.ZipCode = txtZipCode.Text;
            locationItem.ZipCodePlusFour = txtZipCodePlusFour.Text;

            HiddenGymId.Value = drpGymName.SelectedValue;
            int recordId = LocationManager.SaveItem(locationItem);


        }
        #endregion

        #region ||=======  RESET TEXT FIELD  =======||
        protected void ResetTextField()
        {
            drpGymName.SelectedValue = HiddenGymId.Value;
            txtLocationName.Text = string.Empty;
            txtAddress01.Text = string.Empty;
            txtAddress02.Text = string.Empty;
            txtCity.Text = string.Empty;
            drpStateName.SelectedValue = "0";
            txtZipCode.Text = string.Empty;
            txtZipCodePlusFour.Text = string.Empty;
        }
        #endregion

        #region ||=======  RELOAD PAGE  =======||
        protected void ReloadPage()
        {
            Response.Redirect("LocationManage.aspx");
        }
        #endregion

        #region ||=======  VALIDATE FORM  =======||

        #endregion

        #endregion

        #region SECTION 2 ||=======  BINDING  =======||

        #region ||=======  BIND GYM-AREA NAVIGATION  =======||
        protected void BindNavigation()
        {
            gymLocationNavigation.CurrentNavigationLink = GymLocationNavigation.Location;
        }
        #endregion

        #region ||=======  BIND DROP DOWN | GYM NAME  =======||
        protected void BindGymNames()
        {
            GymCollection gymNameCollection = GymManager.GetCollection();

            gymNameCollection.Insert(0, new Gym() { GymName = "(Select Gym)", GymId = 0 });
            drpGymName.DataSource = gymNameCollection;
            drpGymName.DataBind();
        }
        #endregion

        #region ||=======  BIND DROP DOWN | STATE NAME  =======||
        protected void BindDrpStateName()
        {
            StateCollection stateCollection = StateManager.GetCollection();
            stateCollection.Insert(0, new State() { StateName = "(Select State)", StateId = 0 });

            drpStateName.DataSource = stateCollection;
            drpStateName.DataBind();

        }
        #endregion

        #region ||=======  BIND LOCATION LIST | BY GYM-ID  =======||
        protected void BindLocationList(int selectedGymId)
        {
            LocationCollection locationCollection = LocationManager.GetCollection();
            List<Location> parseList = new List<Location>();

            for (int i = 0; i < locationCollection.Count; i++)
            {
                if (locationCollection[i].Gym.GymId == selectedGymId)
                {
                    parseList.Add(locationCollection[i]);
                }
            }

            rptLocationList.DataSource = parseList;
            rptLocationList.DataBind();
        }
        #endregion

        #region ||=======  BIND UPDATE/EDIT INFO | BY LOCATION-ID  =======||
        protected void BindUpdateInfo(int locationId)
        {
            Location locationItem = LocationManager.GetItem(locationId);

            drpGymName.SelectedValue = locationItem.Gym.GymId.ToString();
            txtLocationName.Text = locationItem.LocationName.ToString();
            txtAddress01.Text = locationItem.Address01;
            txtAddress02.Text = locationItem.Address02;
            txtCity.Text = locationItem.City;
            drpStateName.SelectedValue = locationItem.State.StateId.ToString();
            txtZipCode.Text = locationItem.ZipCode;
            txtZipCodePlusFour.Text = locationItem.ZipCodePlusFour;
        }

        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING  =======||

        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING, BROKEN-RULES-COLLECTION  =======||

        #endregion

        #endregion

        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CANCEL_CLICK  =======||
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            HiddenGymId.Value = drpGymName.SelectedValue;
            ReloadPage();
            //ResetTextField();
            SaveButton.Text = "Add Location";
            CancelButton.Visible = false;
        }
        #endregion

        #region ||=======  SAVE_CLICK  =======||
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            ProcessForm();
            ResetTextField();
            ReloadPage();
        }
        #endregion

        #region ||=======  DELETE-AND-EDIT_CLICK  =======||
        protected void LocationBtn_Command(object sender, CommandEventArgs e)
        {

            int locationId = e.CommandArgument.ToString().ToInt();
            if (e.CommandName == "Edit")
            {
                BindUpdateInfo(locationId);
                CancelButton.Visible = true;
                SaveButton.Text = "Update Location";
            }
            else if (e.CommandName == "Delete")
            {
                int deletedRecord = LocationManager.DeleteItem(locationId); 
                BindLocationList(HiddenGymId.Value.ToInt());
            }
        }

        #endregion

        #region ||=======  ON-SELECTED-DROP-DOWN-GYM-NAME CHANGE  =======||
        protected void drpGymName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gymId = drpGymName.SelectedValue.ToInt();
            BindLocationList(gymId);
        }
        #endregion

        #region ||=======  LOCATION LIST ON-ITEM-DATABOUND  =======||
        protected void LocationList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Location tmpItem = (Location)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = tmpItem.LocationId.ToString();
                deleteButton.CommandArgument = tmpItem.LocationId.ToString();
            }
        }

        #endregion

        #endregion

    }
}