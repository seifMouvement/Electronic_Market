using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApprocheExample.Filters;
using EFDbFirstApprocheExample.Identity;
namespace EFDbFirstApprocheExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ApplicationUser> existingUsers = db.Users.ToList();
            return View(existingUsers);
        }
    }
}