using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDAL : IProductDAL
    {
        List<Product> _products;
        public InMemoryProductDAL()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductID=1,
                    ProductName="Bardak",
                    UnitPrice=15,
                    UnitInStock=3
                },
                new Product
                {
                    ProductID=2,
                    ProductName="Kamera",
                    UnitPrice=150,
                    UnitInStock=5
                },
                new Product
                {
                    ProductID=3,
                    ProductName="Telefon",
                    UnitPrice=500,
                    UnitInStock=65
                },
                new Product
                {
                    ProductID=4,
                    ProductName="Klavye",
                    UnitPrice=154,
                    UnitInStock=1
                }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //ref tipi remove la silemem
            //Product productToDelete=null;
            //foreach (var item in _products)
            //{
            //    if (product.ProductID==item.ProductID)
            //    {
            //        productToDelete = item;
            //    }
            //}
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);//Fİrst veya firstordefault ta kullnılabilir



            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;

        }

        public List<Product> GetAllByCategory(int categoryID)
        {
            return _products.Where(p => p.CategoryID == categoryID).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip ürünü bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);//Fİrst veya firstordefault ta kullnılabilir
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;

        }
    }
}
