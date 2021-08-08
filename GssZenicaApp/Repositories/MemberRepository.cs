using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Member AddMember(Member member)
        {
            _context.Members.Add(member);
            return member;
        }
        public void UpdateMember(Member member)
        {
            _context.Entry(member).State = EntityState.Modified;
        }
        public void DeleteMember(int id)
        {
            var member = _context.Members.SingleOrDefault(t => t.Id == id);
            _context.Members.Remove(member);
        }

        public async Task<Member> GetMember(int id)
        {
            return await _context.Members.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<string> GetMemberName(int id)
        {
            return await _context.Members.Where(x => x.Id == id).Select(x => x.FullName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            return await _context.Members.Include(x => x.BloodType).ToListAsync();
        }

        public async Task<IEnumerable<Gender>> GetAllGenders()
        {
            return await _context.Genders.ToListAsync();
        }
        public async Task<IEnumerable<BloodType>> GetAllBloodTypes()
        {
            return await _context.BloodTypes.ToListAsync();
        }
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }
        public async Task<IEnumerable<MemberType>> GetAllMemberTypes()
        {
            return await _context.MemberTypes.ToListAsync();
        }
        public async Task<IEnumerable<MemberPosition>> GetAllMemberPositions()
        {
            return await _context.MemberPositions.ToListAsync();
        }
    }
}
