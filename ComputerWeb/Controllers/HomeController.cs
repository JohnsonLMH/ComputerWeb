using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComputerWeb.Models;
using ComputerWeb.Models.EF;

namespace ComputerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly computerdbContext _computerdbContext;
        public HomeController(computerdbContext computerdbContext) {
            _computerdbContext = computerdbContext;
        }
        public IActionResult News()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }
        public IActionResult newsdemo()
        {
            return View();
        }

        public IActionResult scj()
        {
            return View();
        }
        public IActionResult mall()
        {
            return View();
        }
        public IActionResult spxqy()
        {
            return View();
        }
        public IActionResult serch()
        {
            return View();
        }

        public IActionResult personal()
        {
            return View();
        }
        public IActionResult afterservice()
        {
            return View();
        }
        public IActionResult manage()
        {
            var pro = _computerdbContext.Product.Where(p => p.ObjId >= 0);
            List<Product> computerlist = new List<Product>();
            computerlist = pro.ToList();
            return View(computerlist);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
