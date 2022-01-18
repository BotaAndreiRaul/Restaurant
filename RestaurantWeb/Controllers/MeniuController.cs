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

        //Get 
        public IActionResult Create()
        {            
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Meniu obj)
        {
            if(obj.Name == obj.Ingredients)
            {
                ModelState.AddModelError("Name", "The Ingrediends field cannot match the Name field ");
            }
            if (ModelState.IsValid)
            {
                mdb.menius.Add(obj);
                mdb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

      
       
    }
}
