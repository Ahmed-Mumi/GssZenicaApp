using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IMember
    {
        Member AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
        Task<Member> GetMember(int id);
        Task<IEnumerable<Member>> GetAllMembers();
        Task<IEnumerable<Gender>> GetAllGenders();
        Task<IEnumerable<BloodType>> GetAllBloodTypes();
        Task<IEnumerable<City>> GetAllCities();
        Task<IEnumerable<MemberType>> GetAllMemberTypes();
        Task<IEnumerable<MemberPosition>> GetAllMemberPositions();
        Task<string> GetMemberName(int id);
    }
}
