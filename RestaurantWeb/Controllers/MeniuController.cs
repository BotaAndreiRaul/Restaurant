using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            if (obj.Name == obj.Ingredients)
            {
                ModelState.AddModelError("Name", "The Ingrediends field cannot match the Name field ");
            }
            if (ModelState.IsValid)
            {
                mdb.menius.Add(obj);
                mdb.SaveChanges();
                TempData["success"] = "Meniu added succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = mdb.menius.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Meniu obj)
        {
            if (obj.Name == obj.Ingredients)
            {
                ModelState.AddModelError("Name", "The Ingrediends field cannot match the Name field ");
            }
            if (ModelState.IsValid)
            {
                Thread thread1 = new Thread(() => editThread(obj));
                mdb.menius.Update(obj);
                mdb.SaveChanges();
                TempData["success"] = "Meniu updated succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public void editThread(Meniu obj)
        {

            mdb.SaveChanges();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = mdb.menius.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Meniu obj)
        {
            if (obj == null)
            {
                return NotFound();
            }          
                mdb.menius.Remove(obj);
                mdb.SaveChanges();
            TempData["success"] = "Meniu deleted succesfully";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meniu = await mdb.menius
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meniu == null)
            {
                return NotFound();
            }

            return View(meniu);
        }
        /*public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = mdb.menius.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }*/
    }
}
