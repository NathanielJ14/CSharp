using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext _context;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }



    [SessionCheck]
    [HttpPost("createwedding")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            MyViewModel myModel = new MyViewModel()
            {
                User = _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("uuid")),
                AllWeddings = _context.Weddings.ToList()
            };
            return View("~/Views/Home/PlanWedding.cshtml", myModel);
        }

        newWedding.UserId = (int)HttpContext.Session.GetInt32("uuid");
        _context.Weddings.Add(newWedding);
        _context.SaveChanges();
        
        return RedirectToAction("Dashboard", "Home");
    }


    



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
