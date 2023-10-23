using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using EFDbFirstApprocheExample.Models;
using EFDbFirstApprocheExample.Filters;
using Compagny.DomainModels;
using Compagny.DataLayer;

namespace EFDbFirstApprocheExample.Controllers
{
    [MyAuthentificationFilter]
    [CustomerAuthorization]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            CompagnyDbContext db = new CompagnyDbContext();
            List<Product> products = db.Products.ToList();
            return View(products);
        }
    }
}