using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IMembershipFee
    {
        void AddMembershipFee(MembershipFee membershipFee);
        void DeleteMembershipFee(int id);
        Task<MembershipFee> GetMembershipFee(int id);
        Task<IEnumerable<MembershipFee>> GetAllMembershipFees();
    }
}
