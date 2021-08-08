using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class EquipmentRepository : IEquipment
    {
        private readonly ApplicationDbContext _context;

        public EquipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }
        public void UpdateEquipment(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;
        }
        public void DeleteEquipment(int id)
        {
            var equipment = _context.Equipments.SingleOrDefault(t => t.Id == id);
            _context.Equipments.Remove(equipment);
        }

        public async Task<Equipment> GetEquipment(int id)
        {
            return await _context.Equipments
                .Include(x => x.EquipmentCategory)
                .Include(x => x.EquipmentCategory.Stock).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipments()
        {
            return await _context.Equipments
                .Include(x => x.MemberPurchased)
                .Include(x => x.EquipmentCategory).ToListAsync();
        }
        public async Task<IEnumerable<EquipmentCategory>> GetAllEquipmentCategory()
        {
            return await _context.EquipmentCategories.ToListAsync();
        }

    }
}
