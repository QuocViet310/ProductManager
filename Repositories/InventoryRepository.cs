using BusinessObjects.Models;
using DataAccessObjects;
using System.Collections.Generic;

namespace Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public void DeleteInventory(ProductInventory inventory)
        {
            ProductInventoryDAO.DeleteInventory(inventory);
        }

        public List<ProductInventory> GetAllInventories()
        {
            return ProductInventoryDAO.GetAllInventories();
        }

        public ProductInventory? GetInventoryById(int productId, short locationId)
        {
            return ProductInventoryDAO.GetInventoryById(productId, locationId);
        }

        public void InsertInventory(ProductInventory inventory)
        {
            ProductInventoryDAO.InsertInventory(inventory);
        }

        public void UpdateInventory(ProductInventory inventory)
        {
            ProductInventoryDAO.UpdateInventory(inventory);
        }
    }
}