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
    public partial class EntityTypeLookup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMasterPageNavigation(MasterNavigation.LookupTables);
            
            if (!IsPostBack)
            {
                BindNavigation();
                BindEntityDropDown();

                if (EntityId > 0)
                {
                    DisplayFormSave(true);
                    BindEntityTypeList(EntityId);
                }
            }
        }

        #region SECTION 1 ||=======  PROCESS  =======||

        #region ||=======  DELETE ITEM | BY ENTITY-TYPE-ID  =======||
        private void DeleteItem(int entityTypeId)
        {
            using (ServiceEntityLookup.EntityLookupServiceClient entityLookupService = new ServiceEntityLookup.EntityLookupServiceClient())
            {
                try
                {
                    entityLookupService.DeleteEntityType(entityTypeId);
                    ReloadPage(drpEntity.SelectedValue.ToInt());
                }
                catch (FaultException<ServiceEntityLookup.EntityLookupServiceFault> ex)
                {
                    DisplayLocalMessage(ex.Message + " " + ex.Detail.ErrorMessage);
                }
            }
        }
        #endregion

        #region ||=======  DISPLAY FORM SAVE  =======||
        public void DisplayFormSave(bool isVisible)
        {
            EntityNameTableRow.Visible = isVisible;
            EntityDisplayNameTableRow.Visible = isVisible;
            SaveButton.Visible = isVisible;
            rptLookupList.Visible = isVisible;

        }

        #endregion

        #region ||=======  PROCESS FORM  =======||
        public void ProcessForm()
        {
            ServiceEntityLookup.EntityTypeDTO itemToSave = new ServiceEntityLookup.EntityTypeDTO();

            itemToSave.EntityId = drpEntity.SelectedValue.ToInt();
            itemToSave.EntityTypeName = txtEntityName.Text.Trim();
            itemToSave.DisplayName = txtEntityDisplayName.Text.Trim();

            if (HiddenEntityTypeId.Value.ToInt() > 0)
                itemToSave.EntityTypeId = HiddenEntityTypeId.Value.ToInt();

            using (ServiceEntityLookup.EntityLookupServiceClient entityLookupService = new ServiceEntityLookup.EntityLookupServiceClient())
            {
                try
                {
                    entityLookupService.SaveEntityType(itemToSave);
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
                Response.Redirect("EntityTypeLookup.aspx?EntityId=" + entityId.ToString());
            else
                Response.Redirect("EntityTypeLookup.aspx");
        }
        #endregion

        #region ||=======  VALIDATE FORM  =======||
        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            if (drpEntity.SelectedValue.Trim().ToInt() == 0)
            {
                brokenRules.Add("Entity", "Please select a valid Entity from the drop-down list.");
                returnValue = false;
            }

            if (string.IsNullOrEmpty(txtEntityName.Text.Trim()))
            {
                brokenRules.Add("Lookup Name", "Required field.");
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

        #region ||=======  BIND ENTITY DROP DOWN LIST  =======||
        private void BindEntityDropDown()
        {
            using (ServiceEntity.EntityServiceClient entityService = new ServiceEntity.EntityServiceClient())
            {
                ServiceEntity.EntityDTOCollection entityCollection = entityService.GetEntityCollection();
                if (entityCollection != null && entityCollection.Count > 0)
                {
                    drpEntity.DataSource = entityCollection;
                    drpEntity.DataBind();

                    drpEntity.Items.Insert(0, new ListItem { Text = "(Select Entity)", Value = "0" });
                    drpEntity.SelectedValue = EntityId.ToString();

                }
                else
                    drpEntity.Items.Add(new ListItem { Text = "Not Available", Value = "0" });
            }
        }
        #endregion

        #region ||=======  BIND ENTITY TYPE LIST  =======||
        private void BindEntityTypeList(int entityId)
        {
            if (entityId > 0)
            {
                using (ServiceEntityLookup.EntityLookupServiceClient entityLookupService = new ServiceEntityLookup.EntityLookupServiceClient())
                {
                    ServiceEntityLookup.EntityTypeDTOCollection entityTypeCollection = entityLookupService.GetEntityTypeCollection(entityId);

                    if (entityTypeCollection != null)
                    {
                        rptLookupList.DataSource = entityTypeCollection;
                        rptLookupList.DataBind();
                    }
                }
            }
        }

        #endregion

        #region ||=======  BIND NAVIGATION  =======||
        private void BindNavigation()
        {
            lookupTablesNavigation.CurrentNavigationLink = LookupTableNavigation.EntityType;
        }

        #endregion

        #region ||=======  BIND UPDATE INFO  =======||
        private void BindUpdateInfo(int entityTypeId)
        {
            using (ServiceEntityLookup.EntityLookupServiceClient entityLookupService = new ServiceEntityLookup.EntityLookupServiceClient())
            {
                try
                {
                    ServiceEntityLookup.EntityTypeDTO itemToUpdate = entityLookupService.GetEntityType(entityTypeId);

                    if (itemToUpdate != null)
                    {
                        HiddenEntityTypeId.Value = itemToUpdate.EntityTypeId.ToString();

                        if (!string.IsNullOrEmpty(itemToUpdate.EntityTypeName))
                            txtEntityName.Text = itemToUpdate.EntityTypeName;
                        if (!string.IsNullOrEmpty(itemToUpdate.DisplayName))
                            txtEntityDisplayName.Text = itemToUpdate.DisplayName;

                        SaveButton.Text = "Update Lookup Value";

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
            ReloadPage(drpEntity.SelectedValue.ToInt());
        }
        #endregion

        #region ||=======  ENTITY-LIST-SELECTED 
        protected void EntityList_Selected(object sender, EventArgs e)
        {
            if (drpEntity.SelectedValue.ToInt() > 0)
            {
                DisplayFormSave(true);
                BindEntityTypeList(drpEntity.SelectedValue.ToInt());
            }
            else
            {
                DisplayFormSave(false);
            }

        }
        #endregion

        #region ||=======  ENTITY-TYPE-BUTTON
        protected void EntityTypeButton_Command(object sender, CommandEventArgs e)
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
                ServiceEntityLookup.EntityTypeDTO entityType = (ServiceEntityLookup.EntityTypeDTO)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = entityType.EntityTypeId.ToString();
                deleteButton.CommandArgument = entityType.EntityTypeId.ToString();
            }
        }
        #endregion

        #region ||=======  SAVE-CLICK 
        protected void Save_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ProcessForm();
            }
        }
        #endregion

        #endregion
    }
}