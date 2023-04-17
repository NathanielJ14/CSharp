using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

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
        string myMessage = "This is the Message";
        return View("Index", myMessage);
    }

    [HttpGet("numbers")]
    public IActionResult Numbers()
    {
        int[] numbers = { 13, 2, 3, 4, 5, 12, 24, 24 };
        return View("Numbers", numbers);
    }

    [HttpGet("user")]
    public IActionResult AUser()
    {
        User newUser = new User()
        {
            FirstName = "Francis",
            LastName = "Knight"
        };

        return View("User", newUser);
    }

    [HttpGet("users")]
    public IActionResult SomeUser()
    {
        List<string> users = new List<string>();
        users.Add("Seth Scumpi");
        users.Add("Dylan Envoy");
        users.Add("Crim Six");
        users.Add("Huke Optic");

        return View("Users", users);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
