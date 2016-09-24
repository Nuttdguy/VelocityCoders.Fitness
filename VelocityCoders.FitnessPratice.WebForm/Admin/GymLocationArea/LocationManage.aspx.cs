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
    public partial class LocationManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGymNames();
            }
        }

        #region SECTION 1 ||=======  PROCESS  =======||

        #region ||=======  DELETE ITEM | BY GYM-ID  =======||

        #endregion

        #region ||=======  PROCESS FORM  =======||

        #endregion

        #region ||=======  RELOAD PAGE  =======||

        #endregion

        #region ||=======  VALIDATE FORM  =======||

        #endregion

        #endregion

        #region SECTION 2 ||=======  BINDING  =======||

        #region ||=======  BIND DROP DOWN | GYM NAME  =======||
        protected void BindGymNames()
        {
            GymCollection gymNameCollection = GymManager.GetCollection();

            gymNameCollection.Insert(0, new Gym() { GymName = "(Select Gym)", GymId = 0 });
            drpGymName.DataSource = gymNameCollection;
            drpGymName.DataBind();
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

        #region ||=======  BIND UPDATE INFO | BY LOCATION-ID  =======||

        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING  =======||

        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING, BROKEN-RULES-COLLECTION  =======||

        #endregion

        #endregion

        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CANCEL_CLICK  =======||

        #endregion

        #region ||=======  SAVE_CLICK  =======||

        #endregion

        #region ||=======  VIEW_CLICK  =======||
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            int selectedGymId = drpGymName.SelectedValue.ToInt();
            BindLocationList(selectedGymId);
        }
        #endregion

        #region ||=======  LOCATION LIST ON-ITEM-DATABOUND  =======||
        protected void LocationList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Location tmpItem = new Location();
                tmpItem = (Location)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = tmpItem.Gym.GymId.ToString();
                deleteButton.CommandArgument = tmpItem.Gym.GymId.ToString();
            }
        }

        #endregion

        #region
        protected void LocationBtn_Command(object sender, CommandEventArgs e)
        {

        }

        #endregion

        #endregion

    }
}