// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Portfolio.Controllers;
public class PortfolioController : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public ViewResult Index()
    {
        return View();
    }


    [HttpGet] // We will go over this in more detail on the next page    
    [Route("projects")] // We will go over this in more detail on the next page
    public ViewResult Projects()
    {
        return View("Projects");
    }


    [HttpGet] // We will go over this in more detail on the next page    
    [Route("contact")] // We will go over this in more detail on the next page
    public ViewResult Contact()
    {
        return View("Contact");
    }
}

