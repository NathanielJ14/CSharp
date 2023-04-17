// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace RazorFun.Controllers;
public class RazorFunController : Controller   // Remember inheritance?    
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }

}

