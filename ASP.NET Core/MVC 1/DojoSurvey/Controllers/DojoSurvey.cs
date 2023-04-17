// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace DojoSurvey.Controllers;
public class DojoSurveyController : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public IActionResult Index()
    {
        return View();
    }

    //form process

    [HttpPost("result")]
    public ViewResult Result(string name, string location, string langauge, string comment)
    {
        Console.WriteLine($"Name: {name}, Location: {location}, Langauge: {langauge}, Comment: {comment}");
        ViewBag.Name = name;
        ViewBag.location = location;
        ViewBag.langauge = langauge;
        ViewBag.Comment = comment;

        return View("result");
    }


}

