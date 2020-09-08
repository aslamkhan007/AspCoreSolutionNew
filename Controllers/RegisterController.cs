using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreSolution.Models;

namespace AspCoreSolution.Controllers
{    
    public class RegisterController : Controller
    {
        private IRegisterBoat _registerboat;

        public RegisterController(IRegisterBoat registerboat)
        {
            _registerboat = registerboat;
        }

        public IActionResult Index()
        {
            var model = _registerboat.GetAllBoats();
            return View(model);
        }


        [HttpGet]
        public IActionResult RegisterCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCreate([Bind] RegisterBoat cust)
        {
            if (ModelState.IsValid)
            {
                ViewData["result"] = _registerboat.AddBoats(cust);
            }
            return View(cust);
        }
    }
}