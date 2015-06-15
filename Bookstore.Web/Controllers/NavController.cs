using System.Web.Mvc;

namespace Bookstore.Web.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult TopMenu()
        {
            return PartialView();
        }

        public PartialViewResult Menu(string category = "dashboard", string subcategory = null)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedSubcategory = subcategory;

            return PartialView();
        }
    }
}