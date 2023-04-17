using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }




    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("login")]
    public IActionResult Login(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return Index();
        }

        HttpContext.Session.SetString("Name", newUser.Name);
        HttpContext.Session.SetInt32("Num", 22);

        return RedirectToAction("Dashboard");
    }

    [HttpPost("logout")]
    public IActionResult logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("");
    }


    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("Name") == null || HttpContext.Session.GetInt32("Num") == null)
        {
            return RedirectToAction("Index");
        }
        return View("Dashboard");
    }


    [HttpGet("addone")]
    public IActionResult AddOne()
    {
        if (HttpContext.Session.GetString("Name") == null || HttpContext.Session.GetInt32("Num") == null)
        {
            return RedirectToAction("Index");
        }

        int? num = HttpContext.Session.GetInt32("Num");
        int newNum = (int)num + 1;

        HttpContext.Session.SetInt32("Num", newNum);

        return RedirectToAction("Dashboard");
    }


    [HttpGet("minone")]
    public IActionResult MinOne()
    {
        if (HttpContext.Session.GetString("Name") == null || HttpContext.Session.GetInt32("Num") == null)
        {
            return RedirectToAction("Index");
        }

        int? num = HttpContext.Session.GetInt32("Num");
        int newNum = (int)num - 1;

        HttpContext.Session.SetInt32("Num", newNum);

        return RedirectToAction("Dashboard");
    }


    [HttpGet("timestwo")]
    public IActionResult TimesTwo()
    {
        if (HttpContext.Session.GetString("Name") == null || HttpContext.Session.GetInt32("Num") == null)
        {
            return RedirectToAction("Index");
        }

        int? num = HttpContext.Session.GetInt32("Num");
        int newNum = (int)num * 2;

        HttpContext.Session.SetInt32("Num", newNum);

        return RedirectToAction("Dashboard");
    }

    [HttpGet("addrandom")]
    public IActionResult AddRandom()
    {
        if (HttpContext.Session.GetString("Name") == null || HttpContext.Session.GetInt32("Num") == null)
        {
            return RedirectToAction("Index");
        }

        Random rand = new Random();
        int randNum = rand.Next(1, 11);

        int? num = HttpContext.Session.GetInt32("Num");
        int newNum = (int)num + randNum;

        HttpContext.Session.SetInt32("Num", newNum);

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
