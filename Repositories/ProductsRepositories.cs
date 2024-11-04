using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsRepositories : IProductsRepositories
    {
        public List<Product> GetAllProducts()
        {
            return ProductDAO.GetAllProduct();
        }

        public List<Product> GetProductsByName(string searchName)
        {
            return ProductDAO.GetAllProductByName(searchName);
        }

        public void CreateProduct(Product product)
        {
            ProductDAO.createProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            ProductDAO.updateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            ProductDAO.deleteProduct(product);
        }
    }
}
