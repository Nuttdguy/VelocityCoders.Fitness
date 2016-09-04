using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.Instructors
{
    public partial class ContactInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindContactNavigation();

            if (!IsPostBack)
            {
                BindEmailType();
                BindEmailList();
            }
            else
            {
                int testInt = Convert.ToInt32(txtEmailAddress.Text);
            }
        }

        private void BindContactNavigation()
        {
            #region IMPLEMENTATION FOR SETTING THE CURRENT PAGE FOR NAVIGATION MENU
            instructorNavigation.CurrentNavigationLink = InstructorNavigation.ContactInfo;
            instructorNavigation.InstructorId = base.InstructorId;
            #endregion
        }

        protected void BindEmailType()
        {
            EntityTypeCollectionList emailTypeList = EntityTypeManager.GetCollection(EntityNames.EmailType, QuerySelectType.GetEntityType);

            emailTypeList.Insert(0, new EntityType { EntityTypeName = "(Select One)", EntityTypeId = 0 });

            drpEmailType.DataSource = emailTypeList;
            drpEmailType.DataBind();
        }

        private void BindEmailList()
        {
            EmailAddressCollection emailList = EmailAddressManager.GetCollection(base.InstructorId);

            rptEmailList.DataSource = emailList;
            rptEmailList.DataBind();
        }

        private void ProcessEmail()
        {
            EmailAddress emailToSave = new EmailAddress(drpEmailType.SelectedValue.ToInt(), txtEmailAddress.Text);

            emailToSave.EmailId = hidEmailId.Value.ToInt();
            InstructorManager.SaveEmail(InstructorId, emailToSave);

            Response.Redirect("ContactInfo.aspx?InstructorId=" + base.InstructorId.ToString());
        }

        protected void EmailButton_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    this.BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;
                case "Delete":
                    this.DeleteEmail(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }


        protected void EmailList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EmailAddress emailAddress = (EmailAddress)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = emailAddress.EmailId.ToString();
                deleteButton.CommandArgument = emailAddress.EmailId.ToString();
            }
        }


        private void BindUpdateInfo(int emailId)
        {

            EmailAddress emailAddress = EmailAddressManager.GetItemByEmailId(emailId);
            if (emailAddress != null)
            {
                hidEmailId.Value = emailAddress.EmailId.ToString();

                if (emailAddress.EmailValue != null)
                {
                    txtEmailAddress.Text = emailAddress.EmailValue;
                }

                if (emailAddress.EmailType != null)
                {
                    drpEmailType.SelectedValue = emailAddress.EmailType.EntityTypeId.ToString();
                }

                SaveButton.Text = "Save Email";

            }
            else
                base.DisplayPageMessage(lblPageMessage, "Email Address could not be retrieved. Contact an administrator.");

        }

        private void DeleteEmail(int emailId)
        {
            if (EmailAddressManager.Delete(emailId))
            {
                Response.Redirect("ContactInfo.aspx?InstructorId=" + base.InstructorId.ToString());
            }
            else
            {
                base.DisplayPageMessage(lblPageMessage, "Delete of email failed. Contact administrator.");
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessEmail();
        }
    }
}