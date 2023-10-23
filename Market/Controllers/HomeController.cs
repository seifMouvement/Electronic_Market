using EFDbFirstApprocheExample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFirstApprocheExample.Controllers
{
    [MyActionFilter]
    [MyResultFilter]
    [OutputCache(Duration =60)]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}