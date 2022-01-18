using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.Data;
using RestaurantWeb.Models;

namespace RestaurantWeb.Controllers
{
    public class MeniuController : Controller
    {
        private readonly MeniuDbContext mdb;
        public MeniuController(MeniuDbContext _mdb)
        {
            mdb = _mdb;
        }
        public IActionResult Index()
        {
            IEnumerable<Meniu> objMeniuList = mdb.menius;
            return View(objMeniuList);
        }
    }
}
