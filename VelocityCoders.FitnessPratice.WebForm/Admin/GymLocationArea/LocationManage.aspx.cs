using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPratice.WebForm.Models;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.GymLocationArea
{
    public partial class LocationManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindNavigation();
                BindGymNameDropDown();
                BindDrpStateName();
            }
        }

        #region ||========  FIELDS  =======||
        private string _baseServiceURI = "http://localhost:60546/LocationService/";
        private string _baseGymServiceURI = "http://localhost:60546/GymService/";
        private string _baseStateServiceURI = "http://localhost:60546/StateService/";
        #endregion

        #region SECTION 1 ||=======  PROCESS  =======||

        #region ||=======  PROCESS FORM  =======||
        protected void ProcessForm()
        {
            LocationDTO locationItem = new LocationDTO();
            string serviceURL = _baseServiceURI + "Location/";

            locationItem.GymDTO.GymId = drpGymName.SelectedValue.ToInt();
            locationItem.LocationName = txtLocationName.Text;
            locationItem.Address01 = txtAddress01.Text;
            locationItem.Address02 = txtAddress02.Text;
            locationItem.City = txtCity.Text;
            locationItem.StateDTO.StateId = drpStateName.SelectedValue.ToInt();
            locationItem.ZipCode = txtZipCode.Text;
            locationItem.ZipCodePlusFour = txtZipCodePlusFour.Text;

            HiddenGymId.Value = drpGymName.SelectedValue;

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = httpClient.PutAsJsonAsync(serviceURL, locationItem).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                        ReloadPage();
                    else
                        DisplayLocalMessage("There was an error saving this location record.");
                }
            }

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
        protected bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection SaveBrokenRulesCollection = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(txtAddress01.Text))
                SaveBrokenRulesCollection.Add("Address is required field. ");
            if (string.IsNullOrEmpty(txtCity.Text))
                SaveBrokenRulesCollection.Add("City is required field. ");
            if (string.IsNullOrEmpty(txtZipCode.Text))
                SaveBrokenRulesCollection.Add("Zip Code is required field. ");
            if (drpStateName.SelectedIndex == 0)
                SaveBrokenRulesCollection.Add("State is required. ");


            if (SaveBrokenRulesCollection.Count > 0)
            {
                DisplayLocalMessage("There were errors processing the form. Please correct and try again.", SaveBrokenRulesCollection);
                returnValue = false;
            }
            return returnValue;

        }
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
        protected void BindGymNameDropDown()
        {
            using (WebClient webClient = new WebClient())
            {

                GymDTO gymDTO = new GymDTO();
                string gymJson = webClient.DownloadString(_baseGymServiceURI + "Gym/Collection/");
                List<GymDTO> gymDTOList = gymDTO.GetGymCollection<GymDTO>(gymJson);

                gymDTOList.Insert(0, new GymDTO() { GymName = "(Select Gym)", GymId = 0 });

                if (gymDTOList != null)
                {
                    drpGymName.DataSource = gymDTOList;
                    drpGymName.DataBind();
                }

            }

        }
        #endregion

        #region ||=======  BIND DROP DOWN | STATE NAME  =======||
        protected void BindDrpStateName()
        {
            using (WebClient webClient = new WebClient())
            {
                StateDTO stateDTOItem = new StateDTO();
                string stateJson = webClient.DownloadString(_baseStateServiceURI + "/State/");
                List<StateDTO> stateDTOList = stateDTOItem.GetStateCollection<StateDTO>(stateJson);

                stateDTOList.Insert(0, new StateDTO() { StateName = "(Select State)", StateId = 0 });
                drpStateName.DataSource = stateDTOList;
                drpStateName.DataBind();
            }

        }
        #endregion

        #region ||=======  BIND LOCATION LIST | BY GYM-ID  =======||
        protected void BindGymLocationList(int selectedGymId)
        {

            using (WebClient webClient = new WebClient())
            {

                LocationDTO locDTO = new LocationDTO();
                string locJson = webClient.DownloadString(_baseServiceURI + "/Location/");
                List<LocationDTO> locDTOList = locDTO.GetLocationCollection<LocationDTO>(locJson);

                List<LocationDTO> parseList = new List<LocationDTO>();

                for (int i = 0; i < locDTOList.Count; i++)
                {
                    if (locDTOList[i].GymDTO.GymId == selectedGymId)
                    {
                        parseList.Add(locDTOList[i]);
                    }
                }

                rptLocationList.DataSource = parseList;
                rptLocationList.DataBind();

            }

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
        protected void DisplayLocalMessage(string message)
        {
            DisplayLocalMessage(message, new BrokenRuleCollection() );
        }
        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING, BROKEN-RULES-COLLECTION  =======||
        protected void DisplayLocalMessage(string message, BrokenRuleCollection brokenRules)
        {
            customMessageArea.Visible = true;
            customMessageArea.Message = message;

            if (brokenRules.Count > 0)
            {
                customMessageArea.BrokenRules = brokenRules;
            }

            customMessageArea.Display();
        }

        #endregion

        #endregion

        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CANCEL_CLICK  =======||
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            HiddenGymId.Value = drpGymName.SelectedValue;
            ReloadPage();
            SaveButton.Text = "Add Location";
            CancelButton.Visible = false;
        }
        #endregion

        #region ||=======  SAVE_CLICK  =======||
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ProcessForm();
                ResetTextField();
                ReloadPage();
            }
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
                BindGymLocationList(HiddenGymId.Value.ToInt());
            }
        }

        #endregion

        #region ||=======  ON-SELECTED-DROP-DOWN-GYM-NAME CHANGE  =======||
        protected void drpGymName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gymId = drpGymName.SelectedValue.ToInt();
            BindGymLocationList(gymId);
            BindDrpStateName();
            customMessageArea.Visible = false;
        }
        #endregion

        #region ||=======  LOCATION LIST ON-ITEM-DATABOUND  =======||
        protected void LocationList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                LocationDTO tmpItem = (LocationDTO)e.Item.DataItem;

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