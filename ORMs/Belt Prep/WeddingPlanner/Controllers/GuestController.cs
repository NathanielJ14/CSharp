using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;


namespace WeddingPlanner.Controllers;

public class GuestController : Controller
{
    private readonly ILogger<GuestController> _logger;
    private MyContext _context;

    public GuestController(ILogger<GuestController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }




    [HttpGet("/rsvp/{weddingId}/create")]
    public IActionResult RSVPCreate(int weddingId, Guest newGuest)
    {

        MyViewModel MyModel = new MyViewModel()
        {
            User = _context.Users.Include(u => u.AllWeddings).SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("uuid")),
            AllWeddings = _context.Weddings.ToList(),
            AllGuest = _context.Guests.ToList()
        };

        newGuest.UserId = (int)HttpContext.Session.GetInt32("uuid");
        newGuest.WeddingId = weddingId;
        newGuest.FirstName = MyModel.User.FirstName;
        newGuest.LastName = MyModel.User.LastName;

        

        _context.Guests.Add(newGuest);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", "Home");

    }


    [HttpGet("/rsvp/{weddingId}/delete")]
    public IActionResult RSVPDelete(int weddingId)
    {
        int userId = (int)HttpContext.Session.GetInt32("uuid");
        Guest? guestToDelete = _context.Guests.SingleOrDefault(g => g.UserId == userId && g.WeddingId == weddingId);

        if (guestToDelete == null)
        {
            return RedirectToAction("Dashboard", "Home");
        }

        _context.Guests.Remove(guestToDelete);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", "Home");
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
