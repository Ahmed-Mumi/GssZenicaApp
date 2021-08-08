using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class MembershipFeeRepository : IMembershipFee
    {
        private readonly ApplicationDbContext _context;

        public MembershipFeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddMembershipFee(MembershipFee membershipFee)
        {
            _context.MembershipFees.Add(membershipFee);
        }
        public void DeleteMembershipFee(int id)
        {
            var MembershipFee = _context.MembershipFees.SingleOrDefault(t => t.Id == id);
            _context.MembershipFees.Remove(MembershipFee);
        }

        public async Task<MembershipFee> GetMembershipFee(int id)
        {
            return await _context.MembershipFees.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<MembershipFee>> GetAllMembershipFees()
        {
            return await _context.MembershipFees
                .Include(x => x.Member)
                .Include(x => x.MembershipFeeCategory).ToListAsync();
        }
    }
}
