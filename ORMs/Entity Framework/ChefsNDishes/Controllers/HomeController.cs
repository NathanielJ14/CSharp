using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet("/")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList();
        ViewBag.AllChefs = AllChefs;
        return View("Index");
    }


    [HttpGet("addchef")]
    public IActionResult AddChef()
    {
        return View("AddChef");
    }

    [HttpPost("createchef")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        else
        {
            return AddChef();
        }
    }



    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Creator).ToList();
        return View("Dishes", AllDishes);
    }




    [HttpGet("adddish")]
    public IActionResult AddDish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("AddDish");
    }

    [HttpPost("createdish")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            return AddDish();
        }

        _context.Dishes.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("Dishes");
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
