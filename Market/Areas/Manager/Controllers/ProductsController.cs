//using EFDbFirstApprocheExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Compagny.DomainModels;
using Compagny.DataLayer;
using Compagny.ServiceContracts;
using Compagny.ServiceLayer;

namespace EFDbFirstApprocheExample.Areas.Manager.Controllers
{
    public class ProductsController : Controller
    {
        CompagnyDbContext db = new CompagnyDbContext();
        // GET: Manager/Products
        public ActionResult Index(string search = "",
            string SortColumn = "ProductName", string IconClass = "fa-sort-asc",
            int PageNo = 1)
        {
            Utils util = new Utils();
            ViewBag.search = search;
            List<Product> products = db.Products.Where
                (temp => temp.ProductName.Contains(search)).ToList();

            /*Sorting*/
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            products = util.sorting(ViewBag.SortColumn, ViewBag.IconClass, products);

            /* Paging */
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count)
                / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(products);
        }

        public ActionResult Details(long id)
        {
            Product p = db.Products.Where(temp => temp.ProductID == id)
                .FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID, ProductName, Price, DateOfPurchase, AvailabilityStatus, CategoryID, BrandID, Active, Photo")] Product p)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            Product existingProduct = db.Products.Where
                (temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    existingProduct.Photo = base64String;
                }
                existingProduct.ProductName = p.ProductName;
                existingProduct.Price = p.Price;
                existingProduct.DateOfPurchase = p.DateOfPurchase;
                existingProduct.CategoryID = p.CategoryID;
                existingProduct.BrandID = p.BrandID;
                existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                existingProduct.Active = p.Active;

                db.SaveChanges();
            }
            return RedirectToAction("Index", "Products");
        }


    }
}
