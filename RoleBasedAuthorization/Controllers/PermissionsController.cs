using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using RoleBasedAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace RoleBasedAuthorization.Controllers
{
   
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionsController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }
        private List<ControllerActionInfo> GetAllControllerActions()
        {
            var asm = typeof(MvcApplication).Assembly;

            var controllers = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .Select(controllerType => new
                {
                    Controller = controllerType.Name.Replace("Controller", ""),
                    Actions = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                                .Where(m => !m.IsDefined(typeof(NonActionAttribute)))
                                .Select(m => new ControllerActionInfo
                                {
                                    ControllerName = controllerType.Name.Replace("Controller", ""),
                                    ActionName = m.Name,
                                    HttpVerb = m.GetCustomAttributes(typeof(HttpPostAttribute), false).Any() ? "POST" : "GET"
                                })
                                .ToList()
                });

            return controllers.SelectMany(c => c.Actions).ToList();
        }

        public class ControllerActionInfo
        {
            public string ControllerName { get; set; }
            public string ActionName { get; set; }
            public string HttpVerb { get; set; }
        }

        public ActionResult Index()
        {
            var users = _context.Users
                .Where(u => u.Email != "superadmin@gmail.com")
                .Select(u => new UserListVM
                {
                    UserId = u.Id,
                    Email = u.Email
                }).ToList();

            return View(users);
        }

        public class UserListVM
        {
            public string UserId { get; set; }
            public string Email { get; set; }
        }
        public ActionResult AssignPermissions(string userId)
        {
            var actions = GetAllControllerActions();

            var model = actions.Select(a => new PermissionAssignVM
            {
                UserId = userId,
                ControllerName = a.ControllerName,
                ActionName = a.ActionName,
                HttpVerb = a.HttpVerb,
                IsAssigned = _context.Set<IdentityUserClaim>()
                             .Any(c => c.UserId == userId
                                    && c.ClaimType == a.ControllerName
                                    && c.ClaimValue == a.ActionName)
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignPermissions(List<PermissionAssignVM> model)
        {
            foreach (var item in model)
            {
                var exists = _context.Set<IdentityUserClaim>()
                    .Any(c => c.UserId == item.UserId
                           && c.ClaimType == item.ControllerName
                           && c.ClaimValue == item.ActionName);

                if (item.IsAssigned && !exists)
                {
                    _context.Set<IdentityUserClaim>().Add(new IdentityUserClaim
                    {
                        UserId = item.UserId,
                        ClaimType = item.ControllerName,
                        ClaimValue = item.ActionName
                    });
                }
                else if (!item.IsAssigned && exists)
                {
                    var claim = _context.Set<IdentityUserClaim>()
                        .First(c => c.UserId == item.UserId
                                 && c.ClaimType == item.ControllerName
                                 && c.ClaimValue == item.ActionName);
                    _context.Set<IdentityUserClaim>().Remove(claim);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public class PermissionAssignVM
        {
            public string UserId { get; set; }
            public string ControllerName { get; set; }
            public string ActionName { get; set; }
            public string HttpVerb { get; set; }
            public bool IsAssigned { get; set; }
        }

    }
}