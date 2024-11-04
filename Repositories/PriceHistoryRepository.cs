using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;

namespace Repositories
{
    public class PriceHistoryRepository : IPriceHistoryRepository
    {
        public void DeletePriceHistory(ProductPriceHistory priceHistory)
        {
            ProductPriceHistoryDAO.DeletePriceHistory(priceHistory);
        }

        public List<ProductPriceHistory> GetAllPriceHistories()
        {
            return ProductPriceHistoryDAO.GetAllPriceHistories();
        }

        public ProductPriceHistory? GetPriceHistoryById(int id)
        {
            return ProductPriceHistoryDAO.GetPriceHistoryById(id);
        }

        public void InsertPriceHistory(ProductPriceHistory priceHistory)
        {
            ProductPriceHistoryDAO.InsertPriceHistory(priceHistory);
        }

        public void UpdatePriceHistory(ProductPriceHistory priceHistory)
        {
            ProductPriceHistoryDAO.UpdatePriceHistory(priceHistory);
        }
    }
}
