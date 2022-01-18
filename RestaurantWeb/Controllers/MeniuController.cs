using Microsoft.AspNetCore.Mvc;

namespace RestaurantWeb.Controllers
{
    public class MeniuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
