using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class StockRepository : IStock
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
        }
        public void DeleteStock(int id)
        {
            var stock = _context.Stocks.SingleOrDefault(t => t.Id == id);
            _context.Stocks.Remove(stock);
        }
        public void UpdateStock(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return await _context.Stocks.ToListAsync();
        }
        public async Task<Stock> GetStockByEquipmentCategoryId(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x => x.EquipmentCategoryId == id);
        }
    }
}
