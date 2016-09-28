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
            //repeaterControl();
            

        }

        protected void GetLocationItemBtn_Click(object sender, EventArgs e)
        {
            //int id = txtLocationId.Text.ToInt();
            //Location tmpItem = LocationManager.GetItem(id);

            //lblLocationName.Text = tmpItem.LocationName;
            
        }

        protected void repeaterControl()
        {
            LocationCollection tmpList = new LocationCollection();

            tmpList = LocationManager.GetCollection();

            //rptCollection.DataSource = tmpList;
            //rptCollection.DataBind();
        }

        protected void SaveLocationBtn_Click(object sender, EventArgs e)
        {
            Location tmpItem = new Location();
            tmpItem.LocationId = txtSaveLocationId.Text.ToInt();
            tmpItem.LocationName = txtLocationName.Text;

            LocationManager.SaveItem(tmpItem);
        }

        protected void deleteLocationBtn_Click(object sender, EventArgs e)
        {
            int id = txtSaveLocationId.Text.ToInt();
            LocationManager.DeleteItem(id);
        }

        //===============


        protected void SaveStateBtn_Click(object sender, EventArgs e)
        {
            State tmpItem = new State();
            tmpItem.StateId = txtStateId.Text.ToInt();
            tmpItem.StateName = txtStateName.Text;

            StateManager.SaveItem(tmpItem);
        }

        protected void deleteStateBtn_Click(object sender, EventArgs e)
        {
            int id = txtStateId.Text.ToInt();
            StateManager.DeleteItem(id);
        }



        //protected void submitBtn_Click(object sender, EventArgs e)
        //{
        //    Gym tmp = new Gym();

        //    tmp.GymName = txtGymName.Text;
        //    tmp.GymId = txtGymId.Text.ToInt();

        //    GymManager.SaveItem(tmp);

        //}

        //protected void deleteBtn_Click(object sender, EventArgs e)
        //{

        //    int gymId = txtGymId.Text.ToInt();

        //    GymManager.DeleteItem(gymId);

        //}
    }
}