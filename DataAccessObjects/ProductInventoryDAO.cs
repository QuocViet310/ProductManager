using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class ProductInventoryDAO
    {
        public static List<ProductInventory> GetAllInventories()
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            return dbContext.ProductInventories.Include(p => p.Location).Include(x => x.Product).ToList();
        }

        public static void InsertInventory(ProductInventory inventory)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.ProductInventories.Add(inventory);
            dbContext.SaveChanges();
        }

        public static void UpdateInventory(ProductInventory inventory)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.ProductInventories.Update(inventory);
            dbContext.SaveChanges();
        }

        public static void DeleteInventory(ProductInventory inventory)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            dbContext.ProductInventories.Remove(inventory);
            dbContext.SaveChanges();
        }

        public static ProductInventory? GetInventoryById(int productId, short locationId)
        {
            using ProductManagementDbContext dbContext = new ProductManagementDbContext();
            return dbContext.ProductInventories.Find(productId, locationId);
        }
    }
}