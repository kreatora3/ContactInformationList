namespace ContactInformation.WebClient
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Http;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {         
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
