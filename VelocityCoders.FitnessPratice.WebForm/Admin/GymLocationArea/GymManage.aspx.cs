using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using VelocityCoders.FitnessPratice.WebForm.Models;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.GymLocationArea
{
    public partial class GymManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMasterPageNavigation(MasterNavigation.LookupTables);

            if (!IsPostBack)
            {
                BindNavigation();
                BindGymList();
            }
        }

        private string _baseServiceURI = "http://localhost:60546/GymService/";

        #region SECTION 1 ||=======  PROCESS  =======||

        #region ||======= DELETE ITEM | BY GYM-ID  =======||

        private void DeleteItem(int gymId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = httpClient.DeleteAsync(_baseServiceURI + "Gym/Item/" + gymId.ToString()).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                        ReloadPage();
                    else
                        DisplayLocalMessage("There was an error deleting this Gym record.");
                }
            }
        }
        #endregion

        #region ||=======  PROCESS FORM  =======||

        private void ProcessForm()
        {
            GymDTO itemToSave = new GymDTO();
            string serviceURL = _baseServiceURI + "Gym/Item/";

            if (HiddenGymId.Value.ToInt() > 0)
                itemToSave.GymId = HiddenGymId.Value.ToInt();

            itemToSave.GymName = txtGymName.Text.Trim();
            itemToSave.GymAbbreviation = txtGymAbbreviation.Text.Trim();
            itemToSave.Website = txtWebsite.Text.Trim();
            itemToSave.Description = txtDescription.Text.Trim();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = httpClient.PutAsJsonAsync(serviceURL, itemToSave).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                        ReloadPage();
                    else
                        DisplayLocalMessage("There was an error saving this Gym record.");
                }
            }

        }
        #endregion

        #region ||======= RELOAD PAGE  =======||
        private void ReloadPage()
        {
            Response.Redirect("GymManage.aspx");
        }
        #endregion

        #region ||======= VALIDATE FORM  =======||

        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(txtGymName.Text.Trim()))
            {
                brokenRules.Add("Gym Name", "Required field");
                returnValue = false;
            }

            if (!returnValue)
            {
                if (brokenRules.Count == 1)
                    DisplayLocalMessage("There is an error with your submission. Please correct and try again.", brokenRules);
                else
                    DisplayLocalMessage("There were some errors with your submission. Please correct and try again.", brokenRules);
            }
            return returnValue;

        }
        #endregion

        #endregion

        #region SECTION 2 ||=======  BIND CONTROLS  =======||

        #region ||=======  BIND NAVIGATION  =======||
        private void BindNavigation()
        {
            gymLocationNavigation.CurrentNavigationLink = GymLocationNavigation.Gym;
        }
        #endregion

        #region ||=======  BIND GYM LIST =======||
        private void BindGymList()
        {
            using (WebClient webClient = new WebClient())
            {
                GymDTO gymJson = new GymDTO();
                string json = webClient.DownloadString(_baseServiceURI + "Gym/Collection/");
                List<GymDTO> gymList = gymJson.GetGymCollection<GymDTO>(json);

                if (gymList != null)
                {
                    rptGymList.DataSource = gymList;
                    rptGymList.DataBind();
                }
            }
        }
        #endregion

        #region ||=======  BIND UPDATE INFO | BY GYM-ID =======||
        private void BindUpdateInfo(int gymId)
        {
            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(_baseServiceURI + "Gym/Item/" + gymId.ToString());
                GymDTO itemJson = new GymDTO();
                GymDTO itemToUpdate = itemJson.GetGymName<GymDTO>(json);

                if (itemToUpdate != null)
                {
                    HiddenGymId.Value = itemToUpdate.GymId.ToString();

                    if (!string.IsNullOrEmpty(itemToUpdate.GymName))
                        txtGymName.Text = itemToUpdate.GymName;

                    if (!string.IsNullOrEmpty(itemToUpdate.GymAbbreviation))
                        txtGymAbbreviation.Text = itemToUpdate.GymAbbreviation;

                    if (!string.IsNullOrEmpty(itemToUpdate.Website))
                        txtWebsite.Text = itemToUpdate.Website;

                    if (!string.IsNullOrEmpty(itemToUpdate.Description))
                        txtDescription.Text = itemToUpdate.Description;

                    SaveButton.Text = "Update Gym";

                    btnCancel.Visible = true;
                }
                else
                    DisplayLocalMessage("Update failed. Couldn't find Gym record.");
            }
        }
        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING  =======||
        private void DisplayLocalMessage(string message)
        {
            DisplayLocalMessage(message, new BrokenRuleCollection());
        }
        #endregion

        #region ||=======  DISPLAY LOCAL MESSAGE | PARAM STRING, BROKEN-RULE-COLLECTION =======||
        private void DisplayLocalMessage(string message, BrokenRuleCollection brokenRules)
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

        #region SECTION 3 ||=======  EVENT HANDLERS  =======||

        #region ||=======  CANCEL-CLICK  =======||
        protected void Cancel_Click(object sender, EventArgs e)
        {
            ReloadPage();
        }
        #endregion

        #region ||=======  SAVE-CLICK  =======||
        protected void Save_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
                ProcessForm();
        }
        #endregion

        #region ||=======  GYMLIST ON-ITEM-DATA-BOUND  =======||
        protected void GymList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GymDTO gymItem = (GymDTO)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = gymItem.GymId.ToString();
                deleteButton.CommandArgument = gymItem.GymId.ToString();
            }
        }

        #endregion

        #region ||=======  GYMBUTTON COMMAND  =======||
        protected void GymButton_Command(object sender, CommandEventArgs e)
        {
            customMessageArea.Visible = false;

            switch (e.CommandName)
            {
                case "Edit":
                    BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;
                case "Delete":
                    DeleteItem(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }
        #endregion

        #endregion

    }

}