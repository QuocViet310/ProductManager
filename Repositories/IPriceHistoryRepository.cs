using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPriceHistoryRepository
    {
        List<ProductPriceHistory> GetAllPriceHistories();
        void InsertPriceHistory(ProductPriceHistory priceHistory);
        void UpdatePriceHistory(ProductPriceHistory priceHistory);
        void DeletePriceHistory(ProductPriceHistory priceHistory);
        ProductPriceHistory? GetPriceHistoryById(int id);
    }
}
