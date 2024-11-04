using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IInventoryRepository
    {
        List<ProductInventory> GetAllInventories();
        void InsertInventory(ProductInventory inventory);
        void UpdateInventory(ProductInventory inventory);
        void DeleteInventory(ProductInventory inventory);
        ProductInventory? GetInventoryById(int productId, short locationId);
    }
}