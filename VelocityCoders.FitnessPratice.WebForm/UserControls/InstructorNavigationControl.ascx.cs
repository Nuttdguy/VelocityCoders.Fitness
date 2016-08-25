using System;
using VelocityCoders.FitnessPractice.Models;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VelocityCoders.FitnessPratice.WebForm.UserControls
{
    public partial class InstructorNavigationControl : System.Web.UI.UserControl
    {
        #region NOTES ABOUT THE IMPLMENTATION OF THIS CODE
        // The members of this "InstructorNavigationalControl" are encapsulated and available to itself only
        // Because of this, the label controls of "System.Web.UI.Page" are not available OR known to this Class
        // This causes Label Control ID of "instructorNavigation" to be not available in this context.
        // ON THE OTHER HAND, because the properties of this CLASS are public, its values can be set utilzing
        // values from Label Control of Page, i.e. instructorNavigation
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorNavigation();
        }

        #region PROPERTIES FOR NAVIGATION 

        public InstructorNavigation CurrentNavigationLink { get; set; }
        public int InstructorId { get; set; }

        #endregion


        #region BINDING CONTROLS FOR NAVIGATION BAR

        private void BindInstructorNavigation()
        {
            //notes: set up collection of list items for links
            //notes: set array containing enum of instructor navigation values
            //notes: set array containing enum of instructor navigation values
            ListItemCollection navigationList = new ListItemCollection();

            Array navigationValues = Enum.GetValues(typeof(InstructorNavigation));

            string instructorIdQueryString = "InstructorId=" + this.InstructorId.ToString();

            if(this.InstructorId > 0)
            {
                foreach (InstructorNavigation item in navigationValues)
                {
                    if (item != InstructorNavigation.None)
                    {
                        string displayValue = item.ToString();

                        if (item == CurrentNavigationLink)
                        {
                            navigationList.Add(new ListItem { Text = displayValue, Value = "", Enabled = false });
                        }
                        else
                            navigationList.Add(new ListItem {
                                Text = displayValue,
                                Value = "~/Admin/Instructors/" + item.ToString() + ".aspx?" + instructorIdQueryString,
                                Enabled = true
                            });
                    }
                }
            }
            else
            {
                //Notes: no InstructorId exists - set all links to inactive
                foreach (InstructorNavigation item in navigationValues)
                {
                    if (item != InstructorNavigation.None)
                    {
                        navigationList.Add(new ListItem
                        {
                            Text = item.ToString(),
                            Value = "~/Admin/Instructors/" + item.ToString() + ".aspx?" + instructorIdQueryString,
                            Enabled = false
                        });
                    }
                }
            }

            //notes: bind list object to front-end control
            InstructorNavigationList.DataSource = navigationList;
            InstructorNavigationList.DataBind();


        }

        #endregion
    }
}