using System.Web.Mvc;

namespace PingPongManagement.Controllers
{
    /// <summary>
    /// Since the front-end is handled and routed by Angular, this controller serves to return the base
    /// Angular application page.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
