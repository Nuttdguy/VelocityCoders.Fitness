using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessPractice.BLL;
using VelocityCoders.FitnessPractice.Models;


namespace VelocityCoders.FitnessPratice.WebForm
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GymCollection gymCollection = new GymCollection();

            //gymCollection = GymManager.GetCollection();

            //rptCollection.DataSource = gymCollection;
            //rptCollection.DataBind();

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            Gym tmp = new Gym();

            tmp.GymName = txtGymName.Text;
            tmp.GymId = txtGymId.Text.ToInt();

            GymManager.SaveItem(tmp);

        }


        protected void deleteBtn_Click(object sender, EventArgs e)
        {

            int gymId = txtGymId.Text.ToInt();

            GymManager.DeleteItem(gymId);

        }
    }
}