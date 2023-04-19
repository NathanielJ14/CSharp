using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }



    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("uuid") != null)
        {
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [SessionCheck]
    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        MyViewModel MyModel = new MyViewModel()
        {
            User = _context.Users.Include(u => u.AllWeddings).SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("uuid")),
            AllWeddings = _context.Weddings.ToList(),
            AllGuest = _context.Guests.ToList()
        };
        return View("Dashboard", MyModel);
    }


    [SessionCheck]
    [HttpGet("planwedding")]
    public IActionResult PlanWedding()
    {
        MyViewModel MyModel = new MyViewModel()
        {
            User = _context.Users.Include(u => u.AllWeddings).SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("uuid")),
            AllWeddings = _context.Weddings.ToList(),
            AllGuest = _context.Guests.ToList()

        };

        return View("PlanWedding", MyModel);
    }

    [SessionCheck]
    [HttpGet("/wedding/{weddingId}/view")]
    public IActionResult OneWedding(int weddingId)
    {
        MyViewModel MyModel = new MyViewModel()
        {
            User = _context.Users.Include(u => u.AllWeddings).SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("uuid")),
            AllWeddings = _context.Weddings.ToList(),
            Wedding = _context.Weddings.SingleOrDefault(d => d.WeddingId == weddingId),
            AllGuest = _context.Guests.ToList()

        };

        if (OneWedding == null)
        {
            return RedirectToAction("Index");
        }

        ViewBag.AllGuest = _context.Guests.ToList();

        return View("View", MyModel);
    }


    [HttpGet("/wedding/{weddingId}/delete")]
    public IActionResult Delete(int weddingId)
    {
        Wedding? WeddingToDelete = _context.Weddings.SingleOrDefault(d => d.WeddingId == weddingId);

        if (WeddingToDelete == null)
        {
            return RedirectToAction("Dashboard");
        }

        _context.Weddings.Remove(WeddingToDelete);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
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
