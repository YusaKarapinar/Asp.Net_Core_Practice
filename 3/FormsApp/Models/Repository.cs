using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Phone" });
            _categories.Add(new Category { CategoryId = 2, Name = "Laptop" });

            _products.Add(new Product { ProductId = 1, Name = "iphone 14", Price = 14000, IsActive = true, CategoryId = 1, Image = "1.jpg" });
            _products.Add(new Product { ProductId = 2, Name = "iphone 15", Price = 14000, IsActive = true, CategoryId = 1, Image = "2.jpg" });
            _products.Add(new Product { ProductId = 3, Name = "Macbook 16", Price = 14000, IsActive = true, CategoryId = 2, Image = "3.jpg" });
            _products.Add(new Product { ProductId = 4, Name = "Macbook 17", Price = 14000, IsActive = true, CategoryId = 2, Image = "4.jpg" });

        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
            
        }


        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }


        public static void CreateProduct(Product entity)
        {
            entity.ProductId = _products.Count + 1;
            _products.Add(entity);
        }



    }
}