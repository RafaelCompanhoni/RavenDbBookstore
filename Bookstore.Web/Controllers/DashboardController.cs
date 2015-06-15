using System.Web.Mvc;

namespace Bookstore.Web.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}