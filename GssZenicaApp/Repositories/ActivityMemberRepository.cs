using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class ActivityMemberRepository : IActivityMember
    {
        private readonly ApplicationDbContext _context;

        public ActivityMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddActivityMember(ActivityMember activityMember)
        {
            _context.ActivityMembers.Add(activityMember);
        }
        public async Task DeleteActivityMember(int id)
        {
            var activityMember = await _context.ActivityMembers.SingleOrDefaultAsync(t => t.Id == id);
            _context.ActivityMembers.Remove(activityMember);
        }

        public async Task<ActivityMember> GetActivityMember(int id)
        {
            return await _context.ActivityMembers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ActivityMember> GetMemberFromActivityByIds(int memberId, int stationActivityId)
        {
            return await _context.ActivityMembers.FirstOrDefaultAsync(x => x.MemberId == memberId && x.StationActivityId == stationActivityId);
        }
        public async Task<IEnumerable<ActivityMember>> GetActivityMembersById(int id)
        {
            return await _context.ActivityMembers.Where(x => x.StationActivityId == id).ToListAsync();
        }

        public async Task<IEnumerable<ActivityMember>> GetAllActivityMembers()
        {
            return await _context.ActivityMembers.ToListAsync();
        }
    }
}
