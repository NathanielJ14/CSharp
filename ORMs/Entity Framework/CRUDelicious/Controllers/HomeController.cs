using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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
        List<Dish> AllDishes = _context.Dishes.ToList();
        ViewBag.AllDishes = AllDishes;
        return View("Index");
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View("Create");
    }

    [HttpPost("formcreate")]
    public IActionResult FormCreate(Dish newInfo)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return Create();
        }
    }

    [HttpGet("/dish/{dishId}/view")]
    public IActionResult ViewOne(int dishId)
    {
        Dish? OneDish = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (OneDish == null)
        {
            return RedirectToAction("Index");
        }
        return View("View", OneDish);
    }


    [HttpGet("/dish/{dishId}/edit")]
    public IActionResult DishEdit(int dishId)
    {
        Dish? OneDish = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (OneDish == null)
        {
            return RedirectToAction("Index");
        }

        return View("DishEdit", OneDish);
    }

    [HttpPost("/dish/{dishId}/update")]
    public IActionResult DishUpdate(int dishId, Dish newDish)
    {
        Dish? OldDish = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (OldDish == null)
        {
            return RedirectToAction("Index");
        }

        OldDish.Name = newDish.Name;
        OldDish.Chef = newDish.Chef;
        OldDish.Calories = newDish.Calories;
        OldDish.Description = newDish.Description;
        OldDish.Tastiness = newDish.Tastiness;
        OldDish.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        return Redirect($"/dish/{dishId}/view");
    }






    [HttpGet("/dish/{dishId}/delete")]
    public IActionResult Delete(int dishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);

        if (DishToDelete == null)
        {
            return RedirectToAction("ViewOne");
        }

        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }







    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
