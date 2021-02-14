using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            {
                new Product {ProductId=1, CategoryId = 1, BrandId=1, ColorId=1, ModelYear = 2005, DailyPrice = 120, Description="Astra"},
                new Product {ProductId=2, CategoryId = 1, BrandId=3, ColorId=1, ModelYear = 2009, DailyPrice = 160, Description="Clio"},
                new Product {ProductId=3, CategoryId = 1, BrandId=2, ColorId=2, ModelYear = 2015, DailyPrice = 300, Description="Passat"},
                new Product {ProductId=4, CategoryId = 1, BrandId=4, ColorId=2, ModelYear = 2013, DailyPrice = 220, Description="Focus"},
                new Product {ProductId=5, CategoryId = 1, BrandId=2, ColorId=3, ModelYear = 2012, DailyPrice = 200, Description="Jetta"},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId );

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.ModelYear = product.ModelYear;
            productToUpdate.Description = product.Description;

        }
    }

    }

