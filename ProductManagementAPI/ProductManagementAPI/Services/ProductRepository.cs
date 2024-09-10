using ProductManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();


        public ProductRepository()
        {
            // Seed with some sample data
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200.99M, Stock = 10 },
                new Product { Id = 2, Name = "Smartphone", Price = 799.99M, Stock = 25 },
                new Product { Id = 3, Name = "Headphones", Price = 199.99M, Stock = 50 }
            };
        }




        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

    }
}
