using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IActivityMember
    {
        void AddActivityMember(ActivityMember activityMember);
        Task DeleteActivityMember(int id);
        Task<ActivityMember> GetActivityMember(int id);
        Task<IEnumerable<ActivityMember>> GetActivityMembersById(int id);
        Task<IEnumerable<ActivityMember>> GetAllActivityMembers();
        Task<ActivityMember> GetMemberFromActivityByIds(int memberId, int stationActivityId);

    }
}
