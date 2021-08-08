using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class EquipmentCategoryRepository : IEquipmentCategory
    {
        private readonly ApplicationDbContext _context;

        public EquipmentCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEquipmentCategory(EquipmentCategory equipmentCategory)
        {
            _context.EquipmentCategories.Add(equipmentCategory);
        }
        public void UpdateEquipmentCategory(EquipmentCategory equipmentCategory)
        {
            _context.Entry(equipmentCategory).State = EntityState.Modified;
        }
        public async Task DeleteEquipmentCategory(int id)
        {
            var equipmentCategory = await _context.EquipmentCategories.SingleOrDefaultAsync(t => t.Id == id);
            _context.EquipmentCategories.Remove(equipmentCategory);
        }

        public async Task<EquipmentCategory> GetEquipmentCategory(int id)
        {
            return await _context.EquipmentCategories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<EquipmentCategory>> GetAllEquipmentCategories()
        {
            return await _context.EquipmentCategories.Include(x => x.Stock).ToListAsync();
        }
    }
}
