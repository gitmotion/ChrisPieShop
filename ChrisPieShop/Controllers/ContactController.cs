using Microsoft.AspNetCore.Mvc;

namespace ChrisPieShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
