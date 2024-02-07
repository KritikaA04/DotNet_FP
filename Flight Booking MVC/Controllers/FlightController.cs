using flightmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
// using APIClient.Models;
// using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
// using System.Web.Mvc;

namespace flightmvc
{
    public class FlightController: Controller
    {   
 
        readonly Ace52024Context db;
        private readonly ISession session;
        public FlightController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }

        public async Task<ActionResult> ShowFlight(string Csource, string Cdestination)
        {
            List<KritikaFlight> filteredFlights = new List<KritikaFlight>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear(); 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5058/api/Flight");

                if (Res.IsSuccessStatusCode)
                { 
                    var fResponse = Res.Content.ReadAsStringAsync().Result;

                    List<KritikaFlight> allFlights = JsonConvert.DeserializeObject<List<KritikaFlight>>(fResponse);
                    if(!String.IsNullOrEmpty(Csource) && !(String.IsNullOrEmpty(Cdestination) ))
                    {
                    filteredFlights = allFlights.Where(f => f.Source == Csource && f.Destination == Cdestination).ToList();
                    return View(filteredFlights);
                    }
                } 
                return RedirectToAction("Index","Home");
            }
        
        }

        [HttpGet]
        public async Task<ActionResult> Visit(int id)
        {
            KritikaFlight showkf = db.KritikaFlights.Where(x=>x.FlightId==id).SingleOrDefault();
            // showkf.FlightId = id;
            // if(filteredFlights.Equals(showkf.FlightId))
            Console.WriteLine(showkf.FlightId);
            if(showkf.FlightId==id)
            {
                HttpContext.Session.SetInt32("fid",showkf.FlightId);
            }
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:5058/api/Flight" + id))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();                    
                        showkf = JsonConvert.DeserializeObject<KritikaFlight>(apiResponse);
                    }
                }  
                return View(showkf);
            }
        
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(KritikaCustomer cs)
        {
            var res= (from i in db.KritikaCustomers
                    where i.CustomerEmail== cs.CustomerEmail && i.Password== cs.Password 
                    select i).SingleOrDefault();
            
            if(res!=null)
            {
                HttpContext.Session.SetInt32("cid",res.CustomerId);
                Console.WriteLine("cidxcidx"+HttpContext.Session.GetInt32("cid"));  
                HttpContext.Session.SetString("customer",res.CustomerName);
                return RedirectToAction("Book");
            }
            else
            {
                return RedirectToAction("RegisterCustomer");
            }
            
        }

        [HttpGet]
        public ActionResult Book()
        {
            int custid=Convert.ToInt32(HttpContext.Session.GetInt32("cid"));
            string logs= custid.ToString();
            // int fxid=FlightId;
            int ftid= Convert.ToInt32(HttpContext.Session.GetInt32("fid"));
            if(String.IsNullOrEmpty(logs) || custid==0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                Console.WriteLine("customer"+logs);
                Console.WriteLine("flight"+ftid);
                KritikaBooking b= new KritikaBooking();
                b.FlightId= ftid;
                b.CustomerId= custid;
                b.BookingDate= DateTime.Now;
                b.NoOfPassengers=1;
                return View(b);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Book(KritikaBooking kb)
        {
            // Console.WriteLine(kb.)
            int ftid= Convert.ToInt32(HttpContext.Session.GetInt32("fid"));
            int traveler= Convert.ToInt32(kb.CustomerId);
            HttpContext.Session.SetInt32("custbooking",traveler);
            var ftxid= db.KritikaFlights.FirstOrDefault(x=>x.FlightId==ftid);
            decimal? ftcharge= ftxid.Price;
            Console.WriteLine("priceprice: "+ftcharge);
            int? people= kb.NoOfPassengers;
            Console.WriteLine("peoplessss: "+people);
            kb.TotalPrice = people * ftcharge;
            // decimal total = kb.TotalPrice;
            KritikaBooking booking = new KritikaBooking
            {
                FlightId = kb.FlightId,
                CustomerId = kb.CustomerId,
                BookingDate = kb.BookingDate,
                NoOfPassengers = kb.NoOfPassengers,
                TotalPrice = kb.TotalPrice
            };
            int bid= booking.BookingId;
            session.SetString("bkid",bid.ToString());
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(kb), 
              Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("http://localhost:5058/api/Booking", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    booking = JsonConvert.DeserializeObject<KritikaBooking>(apiResponse);
                } 
                return RedirectToAction("BookingHistory");
            }
            
        }
        [HttpGet]
        public async Task<ActionResult> BookingHistory()
        {
            int custid=Convert.ToInt32(HttpContext.Session.GetInt32("custbooking"));
            Console.WriteLine("cdcdcdcd"+custid);
            List<KritikaBooking> bookhist = new List<KritikaBooking>(); 
            // var allbook= db.KritikaBookings.Where(x=> x.CustomerId == custid);
            // return View(allbook);
            // foreach (var book in allbook)
            // {
            //     KritikaBooking temp= new KritikaBooking();
            //     temp.BookingId = book.BookingId;
            //     temp.FlightId = book.FlightId;
            //     temp.CustomerId = custid;
            //     temp.BookingDate = book.BookingDate;
            //     temp.NoOfPassengers = book.NoOfPassengers;
            //     temp.TotalPrice = book.TotalPrice;
            //     bookhist.Add(temp);
            // }
            // return View(bookhist);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear(); 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5058/api/Booking");

                if (Res.IsSuccessStatusCode)
                { 
                    var fResponse = Res.Content.ReadAsStringAsync().Result;
                    List<KritikaBooking> allBooking = JsonConvert.DeserializeObject<List<KritikaBooking>>(fResponse);
                    bookhist = allBooking.Where(x=> x.CustomerId == custid).ToList();
                    return View(bookhist);
                } 
                return RedirectToAction("Index","Home");
            
            }
        }

    }
}


//  efcore not with client side