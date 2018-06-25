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
            //后台商品查询
            if (Request.Form["serch1"].ToString()!="")
            {
                string remsg;
                remsg = Request.Form["serch1"].ToString();
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
            //后台用户查询
            if (Request.Form["serch2"].ToString() != "")
            {
                string remsg;
                remsg = Request.Form["serch2"].ToString();
                var user = _computerdbContext.Customer.Where(ID => ID.UserId == int.Parse(remsg));
                List<string> userList = new List<string>();
                foreach (var item in user)
                {
                    userList.Add(item.UserId.ToString());
                    userList.Add(item.Cname.ToString());
                    userList.Add(item.MobilePhone.ToString());
                }
                return userList;
            }

            //后台订单查询
            if (Request.Form["serch3"].ToString() != "")
            {
                string remsg;
                remsg = Request.Form["serch3"].ToString();
                var order = _computerdbContext.ComputerOrder.Where(ID => ID.TheOrder == int.Parse(remsg));
                List<string> orderList = new List<string>();
                foreach (var item in order)
                {
                    orderList.Add(item.TheOrder.ToString());
                    orderList.Add(item.ProductId.ToString());
                    orderList.Add(item.OrderTime.ToString());
                    orderList.Add(item.UserId.ToString());
                    orderList.Add(item.UserId.ToString());
                    orderList.Add(item.OrderState.ToString());
                }
                return orderList;
            }

            //后台员工信息查询
            if (Request.Form["serch4"].ToString() != "")
            {
                string remsg;
                remsg = Request.Form["serch4"].ToString();
                var staff = _computerdbContext.SystemUser.Where(ID => ID.UserId == int.Parse(remsg));
                List<string> staffList = new List<string>();
                foreach (var item in staff)
                {
                    staffList.Add(item.UserId.ToString());
                    staffList.Add(item.Username.ToString());
                    staffList.Add(item.MobilePhone.ToString());
                    staffList.Add(item.UserState.ToString());
                }
                return staffList;
            }

            return null;
        }
        public ActionResult Searchpro()
        {
            List<Product> itemlist = new List<Product>();
            if(Request.Query["text"].ToString() != "")
            {
                string text = Request.Query["text"].ToString();
                var proItem = from pInfo in _computerdbContext.Product
                            where pInfo.ProductName.Contains(text)
                            select new Product
                            {
                                ProductName = pInfo.ProductName,
                                Price = pInfo.Price,
                                BigImg = pInfo.BigImg
                            };
                foreach (var item in proItem)
                {
                    itemlist.Add(item);
                }
                ViewData["pro"] = itemlist;
                return View("serch");
            }
            else
            {
                var proItem = from pInfo in _computerdbContext.Product
                              where pInfo.ObjId>=0
                              select new Product
                              {
                                  ProductName = pInfo.ProductName,
                                  Price = pInfo.Price,
                                  BigImg = pInfo.BigImg
                              };
                foreach (var item in proItem)
                {
                    itemlist.Add(item);
                }
                ViewData["pro"] = itemlist;
                return View("serch");
            }
            
                
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
