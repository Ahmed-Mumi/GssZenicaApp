using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class SkillRepository : ISkill
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Skill AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            return skill;
        }
        public void UpdateSkill(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Modified;
        }
        public void DeleteSkill(int id)
        {
            var skill = _context.Skills.SingleOrDefault(t => t.Id == id);
            _context.Skills.Remove(skill);
        }
        public async Task<Skill> GetSkill(int id)
        {
            return await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }
        public void DeleteSKill(int id)
        {
            var skill = _context.Skills.SingleOrDefault(t => t.Id == id);
            _context.Skills.Remove(skill);
        }
        public async Task<IEnumerable<Member>> GetAllSkills()
        {
            return await _context.Members
                .Include(s => s.Skill)
                .Include(s => s.Skill.SkiingCategory)
                .Include(s => s.Skill.SarCategory)
                .Include(s => s.Skill.GuideCategory)
                .Include(s => s.Skill.DivingCategory)
                .ToListAsync();
        }
        public async Task<IEnumerable<SkiingCategory>> GetAllSkiingCategories()
        {
            return await _context.SkiingCategories.ToListAsync();
        }
        public async Task<IEnumerable<DivingCategory>> GetAllDivingCategories()
        {
            return await _context.DivingCategories.ToListAsync();
        }
        public async Task<IEnumerable<GuideCategory>> GetAllGuideCategories()
        {
            return await _context.GuideCategories.ToListAsync();
        }
        public async Task<IEnumerable<SarCategory>> GetAllSarCategories()
        {
            return await _context.SarCategories.ToListAsync();
        }
    }
}
