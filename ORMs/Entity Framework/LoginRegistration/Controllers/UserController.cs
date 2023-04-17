using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LoginRegistration.Models;

namespace LoginRegistration.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }




    [HttpPost("/user/Create")]
    public IActionResult userCreate(User newuser)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/Home/Index.cshtml");
        }

        PasswordHasher<User> hasher = new PasswordHasher<User>();
        newuser.Password = hasher.HashPassword(newuser, newuser.Password);

        _context.Users.Add(newuser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("uuid", newuser.UserId);


        return RedirectToAction("Dashboard", "Home");
    }


    [HttpGet("user/logout")]
    public IActionResult userLogout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost("/user/login")]
    public IActionResult UserLogin(UserLogin newUser)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/Home/Index.cshtml");
        }


        User? userInDb = _context.Users.SingleOrDefault(u => u.Email == newUser.EmailLogin);
        
        if (userInDb == null)
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
            return View("~/Views/Home/Index.cshtml");
        }

        PasswordHasher<UserLogin> hasher = new PasswordHasher<UserLogin>();
        var result = hasher.VerifyHashedPassword(newUser, userInDb.Password, newUser.PasswordLogin);

        if (result == 0)
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
            return View("~/Views/Home/Index.cshtml");
        }

        HttpContext.Session.SetInt32("uuid", userInDb.UserId);

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
