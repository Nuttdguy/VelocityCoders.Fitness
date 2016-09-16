using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.FitnessPratice.WebForm
{
    public partial class ServiceExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceHelloWorld.HelloWorldClient testService = new ServiceHelloWorld.HelloWorldClient();

            HelloWorldMessage.Text = testService.GetHelloWorld("Daniel");

            HelloWorldMessage.Text += "<br/><br/>" + testService.GetHelloWorld(string.Empty);

        }
    }
}