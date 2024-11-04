using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductCostHistoryService : IProductCostHistoryService
    {
        private readonly IProductCostHistoryRepository iProductCostHistoryRepository;
        public ProductCostHistoryService() => iProductCostHistoryRepository = new ProductCostHistoryRepository();

       

        public List<ProductCostHistory> GetAllProductCostHistories()
        {
            return iProductCostHistoryRepository.GetAllProductCostHistories();
        }

        public List<ProductCostHistory> GetProductCostHistoriesByProductId(int productId)
        {
            return iProductCostHistoryRepository.GetProductCostHistoriesByProductId(productId);
        }

        public void UpdateProductCostHistory(ProductCostHistory productCostHistory)
        {
            iProductCostHistoryRepository.UpdateProductCostHistory(productCostHistory);
        }

        public void DeleteProductCostHistory(ProductCostHistory productCostHistory)
        {
            iProductCostHistoryRepository.DeleteProductCostHistory(productCostHistory);
        }

        public void CreateProductCostHistory(ProductCostHistory productCostHistory)
        {
            iProductCostHistoryRepository.CreateProductCostHistory(productCostHistory);
        }
    }
}
