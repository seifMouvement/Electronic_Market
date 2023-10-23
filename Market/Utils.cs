using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
//using EFDbFirstApprocheExample.Models;
using Compagny.DomainModels;
using Compagny.DataLayer;

namespace EFDbFirstApprocheExample
{
    public class Utils
    {
        public List<Compagny.DomainModels.Product> sorting(string SortColumn, string IconClass, List<Compagny.DomainModels.Product> products)
        {
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy
                        (temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.ProductID).ToList();
            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy
                        (temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.ProductName).ToList();
            }
            else if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.Price).ToList();
            }
            else if (SortColumn == "DateOfPurchase")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy
                        (temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.DateOfPurchase).ToList();
            }
            else if (SortColumn == "AvailabilityStatus")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.AvailabilityStatus).ToList();
            }
            else if (SortColumn == "CategoryID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy
                        (temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.Category.CategoryName).ToList();
            }
            else if (SortColumn == "BrandID")
            {
                if (IconClass == "fa-sort-asc")
                    products = products.OrderBy
                        (temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending
                        (temp => temp.Brand.BrandName).ToList();
            }

            return products;
        }

    }
}