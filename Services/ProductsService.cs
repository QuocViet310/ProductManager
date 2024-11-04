using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepositories iProductsRepositories;

        public ProductsService() => iProductsRepositories = new ProductsRepositories();
        

        public List<Product> GetAllProducts()
        {
            return iProductsRepositories.GetAllProducts();
        }

        public List<Product> GetProductsByName(string searchName)
        {
            return iProductsRepositories.GetProductsByName(searchName);
        }

        public void CreateProduct(Product product)
        {
            iProductsRepositories.CreateProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            iProductsRepositories.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            iProductsRepositories.DeleteProduct(product);
        }
    }
}
