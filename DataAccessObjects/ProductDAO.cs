using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> GetAllProduct()
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            return dbContext.Products.ToList();
        }

        public static List<Product> GetAllProductByName(string searchName)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            return dbContext.Products.Where(p => p.Name.Contains("searchName")).ToList();
        }

        public static void updateProduct(Product product)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
        }

        public static void deleteProduct(Product product)
        {
            try
            {
                using ProductManagementDbContext dbContext = new ProductManagementDbContext();
                Product pro = dbContext.Products.Include(r => r.ProductInventories)
                    .Include(x => x.ProductCostHistories)
                    .Include(q => q.ProductPriceHistories)
                    .FirstOrDefault(p => p.ProductId == product.ProductId);
                if(pro.ProductInventories != null)
                {
                    dbContext.ProductInventories.RemoveRange(pro.ProductInventories);
                }
                if (pro.ProductCostHistories != null)
                {
                    dbContext.ProductCostHistories.RemoveRange(pro.ProductCostHistories);
                }
                if (pro.ProductPriceHistories != null)
                {
                    dbContext.ProductPriceHistories.RemoveRange(pro.ProductPriceHistories);
                }
                dbContext.Products.Remove(pro);
                dbContext.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void createProduct(Product product)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
        }
    }
}
