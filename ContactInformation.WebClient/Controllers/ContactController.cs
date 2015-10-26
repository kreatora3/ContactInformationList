namespace ContactInformation.WebClient.Controllers
{
    using System.Web.Mvc;

    public class ContactController : Controller
    {        
        public ActionResult Index()
        {
            return this.View();
        }
    }
}