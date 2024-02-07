using flightmvc.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class AdminController: Controller
    {   

         readonly Ace52024Context db;
        private readonly ISession session;
        public AdminController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(KritikaCustomer cs)
        {
            var res= (from i in db.KritikaCustomers
                    where i.CustomerEmail== cs.CustomerEmail && i.Password== cs.Password 
                    select i).SingleOrDefault();
            
            if(res!=null)
            {
                if(res.CustomerEmail=="admin@gmail.com" && res.Password=="admin")
                {
                    HttpContext.Session.SetString("customer",res.CustomerName);
                    return RedirectToAction("ShowFlightAll");
                }
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        
        public async Task<ActionResult> ShowFlightAll()
        {
            List<KritikaFlight> allfly = new List<KritikaFlight>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear(); 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("http://localhost:5058/api/Flight");

                if (Res.IsSuccessStatusCode)
                { 
                    var fResponse = Res.Content.ReadAsStringAsync().Result;

                    allfly = JsonConvert.DeserializeObject<List<KritikaFlight>>(fResponse);
                } 
                return View(allfly);
            }
        
        }

        public ActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddFlight(KritikaFlight akf)
        {
            KritikaFlight addkf = new KritikaFlight();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(akf), 
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5058/api/Flight", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    addkf = JsonConvert.DeserializeObject<KritikaFlight>(apiResponse);
                }
            }
            return RedirectToAction("ShowFlightAll");
        }  

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Console.WriteLine("editxxxflightxx "+ id);
            KritikaFlight updatekf = new KritikaFlight();
            HttpContext.Session.SetInt32("fedit",id);
            var editflight = db.KritikaFlights.Where(x=>x.FlightId == id).SingleOrDefault();

            using (var Client = new HttpClient())
            {
                using (var response = await Client.GetAsync("http://localhost:5058/api/Flight" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    updatekf = JsonConvert.DeserializeObject<KritikaFlight>(apiResponse);
                }
            }
            return View(editflight);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(KritikaFlight ukf)
        {
            KritikaFlight updatekf = new KritikaFlight();

            using (var httpClient = new HttpClient())
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("fedit"));
                ukf.FlightId=id;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(ukf)
                , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5058/api/Flight" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    updatekf = JsonConvert.DeserializeObject<KritikaFlight>(apiResponse);
                }
            }
            return RedirectToAction("ShowFlightAll");
        }

        [HttpGet]
        // [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            KritikaFlight dekf = new KritikaFlight();
            // List<KritikaFlight> delkff = new List<KritikaFlight>();
            var dkf = db.KritikaFlights.Where(x=>x.FlightId == id).SingleOrDefault();
            HttpContext.Session.SetInt32("delid",id);

            using (var Client = new HttpClient())
            {
                using (var response = await Client.GetAsync("http://localhost:5058/api/Flight" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dekf = JsonConvert.DeserializeObject<KritikaFlight>(apiResponse);
                    // List<KritikaFlight> allFlights= JsonConvert.DeserializeObject<List<KritikaFlight>>(apiResponse);
                    // delkff = allFlights.Where(x=>x.FlightId == id).ToList();
                }
            }
            return View(dkf);
        }


        [HttpPost]
       // [ActionName("DeleteEmployee")]
        public async Task<ActionResult> Delete(KritikaFlight dkf)
        {
            int fdel = Convert.ToInt32(HttpContext.Session.GetInt32("delid"));
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5058/api/Flight" + fdel))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("ShowFlight");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            KritikaFlight showkf = db.KritikaFlights.Where(x=>x.FlightId == id).SingleOrDefault();

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
                //returning the employee list to view  
                return View(showkf);
            }
        
        }
    }
}


//  efcore not with client side