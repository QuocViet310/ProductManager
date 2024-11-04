using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductCostHistoryRepository : IProductCostHistoryRepository
    {
        public List<ProductCostHistory> GetAllProductCostHistories()
        {
            return ProductCostHistoryDAO.GetAllProductCostHistories();
        }

        public List<ProductCostHistory> GetProductCostHistoriesByProductId(int productId)
        {
            return ProductCostHistoryDAO.GetAllProductCostHistoryByName(productId);
        }

        public void UpdateProductCostHistory(ProductCostHistory productCostHistory)
        {
            ProductCostHistoryDAO.updateProductCostHistory(productCostHistory);
        }

        public void DeleteProductCostHistory(ProductCostHistory productCostHistory)
        {
            ProductCostHistoryDAO.deleteProductCostHistory(productCostHistory);
        }

        public void CreateProductCostHistory(ProductCostHistory productCostHistory)
        {
            ProductCostHistoryDAO.createProductCostHistory(productCostHistory);
        }
    }
}
