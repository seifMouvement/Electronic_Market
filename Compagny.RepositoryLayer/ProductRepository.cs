﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compagny.RepositoryContracts;
using Compagny.DomainModels;
using Compagny.DataLayer;

namespace Compagny.RepositoryLayer
{
    public class ProductRepository : IProductsRepository
    {
        CompagnyDbContext db;

        public ProductRepository()
        {
            this.db = new CompagnyDbContext();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(ProductName)).ToList();
            return products;
        }

        public Product GetProductByProductID(long ProductID)
        {
            Product p = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            return p;
        }
        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }
        public void UpdateProduct(Product p)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            existingProduct.Photo = p.Photo;
            db.SaveChanges();
        }
        public void DeleteProduct(long ProductID)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
        }
    }
}
