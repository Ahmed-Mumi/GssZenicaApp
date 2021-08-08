using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IStock
    {
        void AddStock(Stock stock);
        void DeleteStock(int id);
        Task<IEnumerable<Stock>> GetAllStocks();
        void UpdateStock(Stock stock);
        Task<Stock> GetStockByEquipmentCategoryId(int id);
    }
}
