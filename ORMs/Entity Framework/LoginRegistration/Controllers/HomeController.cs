using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;


namespace LoginRegistration.Controllers;

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
        return View("Dashboard");
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
