using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComputerWeb.Models;
using ComputerWeb.Models.EF1;

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
            //int IDresult=Request.Query[""];
            var msg = from result in _computerdbContext.Customer
                      join COresult in _computerdbContext.ComputerOrder on result.UserId equals COresult.UserId
                      join Consigneeresult in _computerdbContext.Consignee on result.UserId equals Consigneeresult.UserId
                      join PResult in _computerdbContext.Product on COresult.ProductId equals PResult.ProductId
                      select new Class
                      {
                          UserId = result.UserId,
                          Cname = result.Cname,
                          MobilePhone = result.MobilePhone,
                          TheOrder = COresult.TheOrder,
                          ProductId = COresult.ProductId,
                          ProductName = PResult.ProductName,
                          Timetommarket = PResult.Timetommarket,
                          ProductState = PResult.ProductState,
                          OrderTime = COresult.OrderTime,
                          Conname = Consigneeresult.Cname,
                          ConMobilePhone = Consigneeresult.MobilePhone,
                          OrderState = COresult.OrderState
                      };
            var susermsg = _computerdbContext.SystemUser.Where(id => id.ObjId >= 0);
            return View(Tuple.Create(msg.ToList<Class>(), susermsg.ToList<SystemUser>()));
        }
        [HttpPost]
        public List<string> manage(string msg)
        {
            
            if (Request.Form["serch"].ToString()!="")
            {
                string remsg;
                remsg = Request.Form["serch"].ToString();
                var pro = _computerdbContext.Product.Where(ID => ID.ProductId == int.Parse(remsg));
                List<string> proList = new List<string>();
                foreach (var item in pro)
                {
                    proList.Add(item.ProductId.ToString());
                    proList.Add(item.ProductName.ToString());
                    proList.Add(item.Timetommarket.ToString());
                    proList.Add(item.ProductState.ToString());
                }
                return proList;
            }
            return null;
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
