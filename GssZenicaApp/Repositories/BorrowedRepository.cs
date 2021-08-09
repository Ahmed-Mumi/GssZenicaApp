using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class BorrowedRepository : IBorrowed
    {
        private readonly ApplicationDbContext _context;

        public BorrowedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBorrow(Borrowed borrowed)
        {
            _context.Borrows.Add(borrowed);
        }
        public void UpdateBorrow(Borrowed borrowed)
        {
            _context.Entry(borrowed).State = EntityState.Modified;
        }
        public async Task DeleteBorrow(int id)
        {
            var borrowed = await _context.Borrows.SingleOrDefaultAsync(t => t.Id == id);
            _context.Borrows.Remove(borrowed);
        }

        public async Task<Borrowed> GetBorrow(int id)
        {
            return await _context.Borrows.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> MemberHasBorrowed(int memberId)
        {
            return await _context.Borrows.FirstOrDefaultAsync(x => x.MemberId == memberId && x.IsActive) == null ? false : true;
        }

        public async Task<IEnumerable<Borrowed>> GetAllBorrows()
        {
            return await _context.Borrows.ToListAsync();
        }
        public async Task<IEnumerable<Borrowed>> GetMembersActiveBorrows(int memberId)
        {
            return await _context.Borrows
                .Include(x => x.EquipmentCategory)
                .Where(x => x.IsActive && x.MemberId == memberId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Borrowed>> GetAllActiveBorrows()
        {
            return await _context.Borrows
                .Include(x => x.Member)
                .Include(x => x.EquipmentCategory)
                .Where(x => x.IsActive).ToListAsync();
        }
        public async Task<IEnumerable<Borrowed>> GetAllInactiveBorrows()
        {
            return await _context.Borrows
                .Include(x => x.Member)
                .Include(x => x.EquipmentCategory)
                .Where(x => !x.IsActive).ToListAsync();
        }
        public async Task<int> GetLastBorrowId()
        {
            if (await _context.Borrows.CountAsync() == 0)
                return 0;
            else
                return await _context.Borrows.MaxAsync(item => item.Id);
        }
    }
}
