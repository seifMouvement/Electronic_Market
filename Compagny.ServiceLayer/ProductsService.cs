﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compagny.ServiceContracts;
using Compagny.DomainModels;
using Compagny.DataLayer;
using Compagny.RepositoryContracts;
using Compagny.RepositoryLayer;
namespace Compagny.ServiceLayer
{
    public class ProductsService:IProductsService
    {
        IProductsRepository prodRep;

        public ProductsService(IProductsRepository r)
        {
            this.prodRep = r;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = prodRep.GetProducts();
            return products;
        }

        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = prodRep.SearchProducts(ProductName);
            return products;
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = prodRep.GetProductByProductID(ProductID);
            return p;
        }
        public void InsertProduct(Product p)
        {
            if (p.Price <= 1000000)
            {
                prodRep.InsertProduct(p);
            }
            else
            {
                throw new Exception("Price exceeds the limit");
            }
        }
        public void UpdateProduct(Product p)
        {
            prodRep.UpdateProduct(p);
        }
        public void DeleteProduct(long ProductID)
        {
            prodRep.DeleteProduct(ProductID);
        }
    }
}
