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
            get { return this.GetQueryStringNumber("InstructorId"); }
        }

        //=========    ERROR METHOD | AVAILABLE FOR ALL PAGES INHERITING BASEPAGE     ===================//
        public void DisplayLocalMessageDisplayPageMessage(Label labelControl, string messageToDisplay)
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


    }
}