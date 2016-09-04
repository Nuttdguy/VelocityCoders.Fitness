using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.Instructors
{
    public partial class InstructorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorList();
        }

        private void BindInstructorList()
        {
            QuerySelectType queryId = QuerySelectType.GetInstructorAndPersonCollection;
            InstructorCollectionList instructorList = InstructorManager.GetInstructorCollection(queryId);

            rptInstructorList.DataSource = instructorList;
            rptInstructorList.DataBind();

        }

    }
}