using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface ISkill
    {
        void UpdateSkill(Skill skill);
        Task<Skill> GetSkill(int id);
        Task<IEnumerable<Member>> GetAllSkills();
        Task<IEnumerable<SkiingCategory>> GetAllSkiingCategories();
        Task<IEnumerable<DivingCategory>> GetAllDivingCategories();
        Task<IEnumerable<GuideCategory>> GetAllGuideCategories();
        Task<IEnumerable<SarCategory>> GetAllSarCategories();
        Skill AddSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
