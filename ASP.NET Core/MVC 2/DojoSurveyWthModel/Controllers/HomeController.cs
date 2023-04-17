using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWthModel.Models;

namespace DojoSurveyWthModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static Info MyInfo {get; set;}
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("create")]
    public IActionResult FormCreate(Info info)
    {   
        if (!ModelState.IsValid)
        {
            return Index();
        }

        Console.WriteLine($"Name: {info.Name}, Location: {info.Location}, Langauge: {info.Langauge}, Comment: {info.Comment}");
        MyInfo = info;
        return RedirectToAction("Results");
    }

    [HttpGet("results" )]
    public ViewResult Results()
    {
        Console.WriteLine($"Name: {MyInfo.Name}, Location: {MyInfo.Location}, Langauge: {MyInfo.Langauge}, Comment: {MyInfo.Comment}");
        return View("Results" , MyInfo);
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
