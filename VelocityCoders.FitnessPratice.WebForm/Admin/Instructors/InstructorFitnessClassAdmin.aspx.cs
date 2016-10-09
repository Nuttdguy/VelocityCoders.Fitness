using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.Instructors
{
    public partial class InstructorFitnessClassAdmin : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetInstructorId();
        }

        private void SetInstructorId()
        {
            litInstructorId.Text = "<input type='hidden' id='InstructorId' value='" + base.InstructorId.ToString() + "' />";
        }
    }
}