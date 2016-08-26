using System;
using VelocityCoders.FitnessPractice.Models;
// using VelocityCoders.FitnessPractice.DAL;
using VelocityCoders.FitnessPractice.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm.Admin.Instructors
{
    public partial class InstructorCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorCollection();
        }


        #region BIND GET_COLLECTION
        private void BindInstructorCollection()
        {
            InstructorCollectionList instructorList = InstructorManager.GetInstructorCollection();
            //instructorList = InstructorDAL.GetCollection();

            repeaterText.DataSource = instructorList;
            repeaterText.DataBind();
        }
        #endregion
    }
}