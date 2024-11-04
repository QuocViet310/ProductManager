using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductCostHistoryDAO
    {
        public static List<ProductCostHistory> GetAllProductCostHistories()
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            return dbContext.ProductCostHistories.ToList();
        }

        public static List<ProductCostHistory> GetAllProductCostHistoryByName(int id)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            return dbContext.ProductCostHistories.Where(p => p.ProductId == id).ToList();
        }

        public static void updateProductCostHistory(ProductCostHistory product)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.ProductCostHistories.Update(product);
            dbContext.SaveChanges();
        }

        public static void deleteProductCostHistory(ProductCostHistory product)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.ProductCostHistories.Remove(product);
            dbContext.SaveChanges();
        }

        public static void createProductCostHistory(ProductCostHistory product)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.ProductCostHistories.Update(product);
            dbContext.SaveChanges();
        }
    }
}
