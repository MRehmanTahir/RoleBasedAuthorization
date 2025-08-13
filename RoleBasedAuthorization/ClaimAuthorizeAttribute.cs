using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RoleBasedAuthorization.Models;
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class ClaimAuthorizeAttribute : ActionFilterAttribute
{
    private readonly string _controllerName;
    private readonly string _actionName;

    public ClaimAuthorizeAttribute(string controllerName = null, string actionName = null)
    {
        _controllerName = controllerName;
        _actionName = actionName;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var userId = filterContext.HttpContext.User.Identity.GetUserId();
        if (string.IsNullOrEmpty(userId))
        {
            filterContext.Result = new HttpUnauthorizedResult();
            return;
        }

        using (var db = new ApplicationDbContext())
        {
            // Agar attribute me controller/action specify nahi kia to current route se le lo
            var controller = _controllerName ?? filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = _actionName ?? filterContext.ActionDescriptor.ActionName;

            var hasClaim = db.Set<Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim>()
                             .Any(c => c.UserId == userId
                                    && c.ClaimType == controller
                                    && c.ClaimValue == action);

            if (!hasClaim)
            {
                // Agar claim nahi hai to 403 Forbidden page show kare
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/AccessDenied.cshtml"
                };
            }
        }

        base.OnActionExecuting(filterContext);
    }
}
