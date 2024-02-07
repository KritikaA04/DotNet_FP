using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flightmvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flightmvc.Controllers
{
    public class CustomerController : Controller
    {
        readonly Ace52024Context db;

        private readonly ISession session;
        public CustomerController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer(KritikaCustomer cs)
        {
            db.KritikaCustomers.Add(cs);
            db.SaveChanges();
            return RedirectToAction("Login","Flight");
        }
#region 
        // public IActionResult Login()
        // {
        //     return View();
        // }
        // [HttpPost]
        // public IActionResult Login(KritikaCustomer cs)
        // {
        //     var res= (from i in db.KritikaCustomers
        //             where i.CustomerEmail== cs.CustomerEmail && i.Password== cs.Password 
        //             select i).SingleOrDefault();
            
        //     if(res!=null)
        //     {
        //             // string location = res.Loc;
        //             // TempData["cloc"]= location;
        //             // int ccid= res.CustomerId;
        //             // TempData["ctid"]= ccid;
        //             // HttpContext.Session.SetString("customer",res.CustomerName);
        //             // return RedirectToAction("ShowFlight","Flight");
        //             if(cs.CustomerEmail=="admin@gmail.com" && cs.Password=="admin")
        //             {
        //                 return RedirectToAction("ShowAllFlights","Flight");
        //             }
        //             return View();
        //     }
        //     else
        //     {
        //         return RedirectToAction("RegisterCustomer");
        //     }
            
        // }
#endregion

    }
}