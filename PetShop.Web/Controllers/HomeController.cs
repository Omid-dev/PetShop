using Microsoft.AspNetCore.Mvc;

namespace PetShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact_us()
        {
            return View();
        }
    }
}