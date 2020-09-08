using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreSolution.Models;

namespace AspCoreSolution.Controllers
{
    public class RentOutController : Controller
    {
        private IRentOutBoat _rentOutBoat;
        public RentOutController(IRentOutBoat rentOutBoat)
        {
            _rentOutBoat = rentOutBoat;
        }

        public IActionResult Index()
        {
            var model = _rentOutBoat.GetAllRentOutBoats();
            return View(model);
        }


        [HttpGet]
        public IActionResult RentOutCreate()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult RentOutCreate([Bind] RentOutBoat cust)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _rentOutBoat.AddRentOutBoats(cust);
        //        return RedirectToAction("Index");
        //    }
        //    return View(cust);
        //}


        [HttpPost]
        public IActionResult RentOutCreate(RentOutBoat cust)
        {
            if (ModelState.IsValid)
            {
                ViewData["result"] = _rentOutBoat.AddRentOutBoats(cust);
                //return RedirectToAction("Index");
            }
            return View(cust);
        }


    }
}