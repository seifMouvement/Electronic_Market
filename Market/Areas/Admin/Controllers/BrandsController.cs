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
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            return View();
        }
    }
}