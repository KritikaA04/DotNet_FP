using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flightmvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flightmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    readonly Ace52024Context db;
    private readonly ISession session;
    // public HomeController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    // {
    //     db = _db;
    //     session = httpContextAccessor.HttpContext.Session;
    // }

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public HomeController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger)
    {
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<string?> sources = db.KritikaFlights.Select(f => f.Source).Distinct().ToList();
        List<string?> destinations = db.KritikaFlights.Select(f => f.Destination).Distinct().ToList();

        ViewBag.Sources = new SelectList(sources);
        ViewBag.Destinations = new SelectList(destinations);
        return View();
    }
    public ActionResult FindFlights(string selsource, string seldestination)
    {
        if(!(String.IsNullOrEmpty(selsource)) && !(String.IsNullOrEmpty(seldestination) ))
        {
            // var sc = db.KritikaFlights.Where(x=> x.Source == selsource && x.Destination == seldestination).ToList();
            HttpContext.Session.SetString("selsrc",selsource);
            HttpContext.Session.SetString("seldtn",seldestination);
            return RedirectToAction("ShowFlight","Flight");
        }
        else
        {
            // ViewBag.msg 
            return View();
        }
        // return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
