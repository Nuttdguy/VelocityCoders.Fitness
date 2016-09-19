using System;
using VelocityCoders.FitnessPractice.Models;
using System.ServiceModel;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea
{
    public partial class EntityLookup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMasterPageNavigation(MasterNavigation.LookupTables);
            BindNavigation();

            if (!IsPostBack)
            {
                BindEntityList();
            }
        }

        #region SECTION 1 ||=======  PROCESS  =======||

        #region ||=======  DELETE ITEM | BY ENTITY-TYPE-ID  =======||
        private void DeleteItem(int entityId)
        {
            using (ServiceEntity.EntityServiceClient entityService = new ServiceEntity.EntityServiceClient())
            {
                try
                {
                    entityService.DeleteEntity(entityId);
                    ReloadPage();
                }
                catch (FaultException<ServiceEntity.EntityLookupServiceFault> ex)
                {
                    DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }
        #endregion

        #region ||=======  PROCESS FORM  =======||
        public void ProcessForm()
        {
            ServiceEntity.EntityDTO entityToSave = new ServiceEntity.EntityDTO();

            entityToSave.EntityName = txtEntityName.Text.Trim();
            entityToSave.DisplayName = txtEntityDisplayName.Text.Trim();
            entityToSave.Description = txtEntityDescription.Text.Trim();

            if (HiddenEntityId.Value.ToInt() > 0)
                entityToSave.EntityId = HiddenEntityId.Value.ToInt();

            using (ServiceEntity.EntityServiceClient entityService = new ServiceEntity.EntityServiceClient())
            {
                try
                {
                    entityService.SaveEntity(entityToSave);
                }
                catch (FaultException<ServiceEntityLookup.EntityLookupServiceFault> ex)
                {
                    DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }
        #endregion

        #region ||=======  RELOAD PAGE  =======||
        private void ReloadPage()
        {
            ReloadPage(0);
        }
        #endregion

        #region ||=======  RELOAD PAGE | BY ENTITY-ID  =======||
        private void ReloadPage(int entityId)
        {
            if (entityId > 0)
                Response.Redirect("EntityLookup.aspx?EntityId=" + entityId.ToString());
            else
                Response.Redirect("EntityLookup.aspx");
        }
        #endregion

        #region ||=======  VALIDATE FORM  =======||
        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(txtEntityName.Text.Trim()))
            {
                brokenRules.Add("Entity Name", "Required field.");
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

        #region ||=======  BIND ENTITY LIST  =======||
        private void BindEntityList()
        {
            using (ServiceEntity.EntityServiceClient entityService = new ServiceEntity.EntityServiceClient())
            {
                ServiceEntity.EntityDTOCollection entityCollection = entityService.GetEntityCollection();

                if (entityCollection != null)
                {
                    rptLookupList.DataSource = entityCollection;
                    rptLookupList.DataBind();
                }
            }
        }

        #endregion

        #region ||=======  BIND NAVIGATION  =======||
        private void BindNavigation()
        {
            lookupTablesNavigation.CurrentNavigationLink = LookupTableNavigation.Entity;
        }

        #endregion

        #region ||=======  BIND UPDATE INFO  =======||
        private void BindUpdateInfo(int entityId)
        {
            using (ServiceEntity.EntityServiceClient entityService = new ServiceEntity.EntityServiceClient())
            {
                try
                {
                    ServiceEntity.EntityDTO itemToUpdate = entityService.GetEntity(entityId);

                    if (itemToUpdate != null)
                    {
                        HiddenEntityId.Value = itemToUpdate.EntityId.ToString();

                        if (!string.IsNullOrEmpty(itemToUpdate.EntityName))
                            txtEntityName.Text = itemToUpdate.EntityName;
                        if (!string.IsNullOrEmpty(itemToUpdate.DisplayName))
                            txtEntityDisplayName.Text = itemToUpdate.DisplayName;

                        SaveButton.Text = "Update Entity Name";

                        btnCancel.Visible = true;
                    }
                    else
                        DisplayLocalMessage("Update failed. Couldn't find record");
                }
                catch (FaultException<ServiceEntityLookup.EntityLookupServiceFault> ex)
                {
                    DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }
        #endregion

        #region ||=======  DISPLAY LOCAL ERROR MESSAGE | STRING  =======||
        private void DisplayLocalMessage(string message)
        {
            DisplayLocalMessage(message, new BrokenRuleCollection());
        }

        #endregion

        #region ||=======  DISPLAY LOCAL ERROR MESSAGE | STRING, BROKEN-RULE-COLLECTION  =======||
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

        #region ||=======  CANCEL-CLICK
        protected void Cancel_Click(object sender, EventArgs e)
        {
            ReloadPage(0);
        }
        #endregion

        #region ||=======  ENTITY-BUTTON
        protected void EntityButton_Command(object sender, CommandEventArgs e)
        {
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

        #region ||=======  LOOKUP-LIST ON-ITEM-DATABOUND
        protected void LookupList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ServiceEntity.EntityDTO entityType = (ServiceEntity.EntityDTO)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = entityType.EntityId.ToString();
                deleteButton.CommandArgument = entityType.EntityId.ToString();
            }
        }
        #endregion

        #region ||=======  SAVE-CLICK 
        protected void Save_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
                ProcessForm();
        }
        #endregion

        #endregion
    }
}