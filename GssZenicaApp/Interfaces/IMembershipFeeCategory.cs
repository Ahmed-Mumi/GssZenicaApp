using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IMembershipFeeCategory
    {
        void AddMembershipFeeCategory(MembershipFeeCategory membershipFeeCategory);
        void UpdateMembershipFeeCategory(MembershipFeeCategory membershipFeeCategory);
        void DeleteMembershipFeeCategory(int id);
        Task<MembershipFeeCategory> GetMembershipFeeCategory(int id);
        Task<IEnumerable<MembershipFeeCategory>> GetAllMembershipFeeCategories();
    }
}
