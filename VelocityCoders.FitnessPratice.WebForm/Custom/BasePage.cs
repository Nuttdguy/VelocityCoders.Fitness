using System;
using VelocityCoders.FitnessPractice.Models;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm
{
    public class BasePage : Page
    {
        public int GetQueryStringNumber(string queryStringName)
        {
            if (Request.QueryString[queryStringName] == null) { return 0; }
            else { return Request.QueryString[queryStringName].ToInt(); }
        }

        public int InstructorId
        {
            get { return GetQueryStringNumber("InstructorId"); }
        }

        public int EntityId
        {
            get { return GetQueryStringNumber("EntityId"); }
        }

        //=========    ERROR METHOD | AVAILABLE FOR ALL PAGES INHERITING BASEPAGE     ===================//
        public void DisplayPageMessage(Label labelControl, string messageToDisplay)
        {
            this.DisplayPageMessage(labelControl, messageToDisplay, false);
        }

        public void DisplayPageMessage(Label labelControl, string messageToDisplay, bool isAppend)
        {
            if (isAppend)
                labelControl.Text += messageToDisplay;
            else
                labelControl.Text = messageToDisplay;
        }

        //=========   METHOD FOR BINDING MAIN-NAVIGATION IN 2 COLUMN MASTER   =========\\
        public void SetMasterPageNavigation(MasterNavigation masterNavigationEnum)
        {
            MasterPages.Site2Column myMasterPage = (MasterPages.Site2Column)Page.Master;
            myMasterPage.SelectedMasterPageNavigation = masterNavigationEnum;
        }


    }
}