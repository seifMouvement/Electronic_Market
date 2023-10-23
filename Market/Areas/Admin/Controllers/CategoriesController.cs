using EFDbFirstApprocheExample.Filters;
//using EFDbFirstApprocheExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Compagny.DomainModels;
using Compagny.DataLayer;

namespace EFDbFirstApprocheExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            CompagnyDbContext db = new CompagnyDbContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}