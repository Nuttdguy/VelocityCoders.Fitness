using System;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.UserControls
{
    public partial class MessageBrokenRulesControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //===  SET PROPERTIES OF USER CONTROL
        public string Message { get; set; }

        public BrokenRuleCollection BrokenRules { get; set; }

        //===  METHOD FOR BINDING

        private void BindMessageArea()
        {
            if (!string.IsNullOrEmpty(this.Message))
                lblPageMessage.Text = this.Message;

            if (this.BrokenRules != null && this.BrokenRules.Count > 0)
            {
                MessageList.DataSource = this.BrokenRules;
                MessageList.DataBind();
            }
        }

        //=== PUBLIC METHOD TO ACCESS MESSAGE
        
        public void Display()
        {
            this.BindMessageArea();
        }

    }
}