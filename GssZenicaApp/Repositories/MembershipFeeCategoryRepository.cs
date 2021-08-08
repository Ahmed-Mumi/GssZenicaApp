using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class MembershipFeeCategoryRepository : IMembershipFeeCategory
    {
        private readonly ApplicationDbContext _context;

        public MembershipFeeCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMembershipFeeCategory(MembershipFeeCategory membershipFeeCategory)
        {
            _context.MembershipFeeCategories.Add(membershipFeeCategory);
        }
        public void UpdateMembershipFeeCategory(MembershipFeeCategory membershipFeeCategory)
        {
            _context.Entry(membershipFeeCategory).State = EntityState.Modified;
        }
        public void DeleteMembershipFeeCategory(int id)
        {
            var membershipFeeCategoryToRemove = _context.MembershipFeeCategories.SingleOrDefault(t => t.Id == id);
            _context.MembershipFeeCategories.Remove(membershipFeeCategoryToRemove);
        }

        public async Task<MembershipFeeCategory> GetMembershipFeeCategory(int id)
        {
            return await _context.MembershipFeeCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MembershipFeeCategory>> GetAllMembershipFeeCategories()
        {
            return await _context.MembershipFeeCategories.ToListAsync();
        }

    }
}
