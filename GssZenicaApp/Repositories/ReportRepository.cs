using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class ReportRepository : IReport
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddReport(Report report)
        {
            _context.Reports.Add(report);
        }
        public void UpdateReport(Report report)
        {
            _context.Entry(report).State = EntityState.Modified;
        }
        public void DeleteReport(int id)
        {
            var report = _context.Reports.SingleOrDefault(t => t.Id == id);
            _context.Reports.Remove(report);
        }
        public async Task<Report> GetReport(int id)
        {
            return await _context.Reports.Include(m => m.Member).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _context.Reports.Include(x => x.Member).ToListAsync();
        }
    }
}
