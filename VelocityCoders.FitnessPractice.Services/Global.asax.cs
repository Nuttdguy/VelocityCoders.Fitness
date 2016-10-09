using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.ServiceModel.Activation;
using VelocityCoders.FitnessPractice.Services.REST;


namespace VelocityCoders.FitnessPractice.Services
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("GymService", new WebScriptServiceHostFactory(), typeof(GymService)));
            RouteTable.Routes.Add(new ServiceRoute("LocationService", new WebScriptServiceHostFactory(), typeof(LocationService)));
            RouteTable.Routes.Add(new ServiceRoute("StateService", new WebScriptServiceHostFactory(), typeof(StateService)));
            RouteTable.Routes.Add(new ServiceRoute("FitnessService", new WebScriptServiceHostFactory(), typeof(FitnessClassService)));
            RouteTable.Routes.Add(new ServiceRoute("InstructorService", new WebScriptServiceHostFactory(), typeof(InstructorService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            this.EnableCrossDomainAjaxCall();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void EnableCrossDomainAjaxCall()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://local.fitness.com");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

    }
}