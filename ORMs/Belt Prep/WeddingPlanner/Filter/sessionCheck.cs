using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? uuid = context.HttpContext.Session.GetInt32("uuid");
        if (uuid == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}