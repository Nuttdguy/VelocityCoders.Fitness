﻿using System;
using VelocityCoders.FitnessPractice.Models;
using VelocityCoders.FitnessPractice.DAL;


namespace VelocityCoders.FitnessPratice.WebForm.Admin
{
    public partial class InstructorDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorItem();
        }

        private void BindInstructorItem()
        {
            int instructorId = Request.QueryString["InstructorId"].ToInt();

            if (instructorId > 0)
            {
                Instructor instructorLookup = InstructorDAL.GetItem(instructorId);
                if (instructorLookup != null)
                {
                    lblInstructorId.Text = instructorLookup.InstructorId.ToString();
                    lblPersonId.Text = instructorLookup.PersonId.ToString();
                    lblHireDate.Text = instructorLookup.HireDate.ToString();
                    lblDescription.Text = instructorLookup.Description.ToString();
                    lblCreateDate.Text = instructorLookup.CreateDate.ToString();
                }
            }

        }
    }
}