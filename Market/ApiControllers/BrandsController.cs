using Compagny.DataLayer;
using Compagny.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Compagny.DomainModels;
using Compagny.DataLayer;

namespace EFDbFirstApprocheExample.ApiControllers
{
    [Authorize(Roles = "Admin")]
    public class BrandsController : ApiController
    {
        public List<Brand> GetBrands()
        {
            CompagnyDbContext db = new CompagnyDbContext();
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }

        public Brand GetBrandsByBrandID(long BrandID)
        {
            CompagnyDbContext db = new CompagnyDbContext();
            Brand existingBrand = db.Brands.Where(temp => temp.BrandID == BrandID).FirstOrDefault();
            return existingBrand;
        }

        public void PostBrand(Brand newBrand)
        {
            CompagnyDbContext db = new CompagnyDbContext();
            db.Brands.Add(newBrand);
            db.SaveChanges();
        }

        public void PutBrand(Brand brandData)
        {
            CompagnyDbContext db = new CompagnyDbContext();
            var existingBrand = db.Brands.Where(temp => temp.BrandID == brandData.BrandID).FirstOrDefault();
            existingBrand.BrandName = brandData.BrandName;
            db.SaveChanges();
        }

        public void DeleteBrand(long BrandID)
        {
            CompagnyDbContext db = new CompagnyDbContext();
            var existingBrand = db.Brands.Where(temp => temp.BrandID == BrandID).FirstOrDefault();
            db.Brands.Remove(existingBrand);
            db.SaveChanges();
        }
    }
}
