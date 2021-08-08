using GssZenicaApp.Data;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Repositories
{
    public class StationActivityRepository : IStationActivity
    {
        private readonly ApplicationDbContext _context;

        public StationActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddStationActivity(StationActivity stationActivity)
        {
            _context.StationActivities.Add(stationActivity);
        }
        public void UpdateStationActivity(StationActivity stationActivity)
        {
            _context.Entry(stationActivity).State = EntityState.Modified;
        }
        public void DeleteStationActivity(int id)
        {
            var stationActivity = _context.StationActivities.SingleOrDefault(t => t.Id == id);
            _context.StationActivities.Remove(stationActivity);
        }
        public async Task<StationActivity> GetStationActivity(int id)
        {
            return await _context.StationActivities.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<StationActivity>> GetAllStationActivities()
        {
            return await _context.StationActivities.ToListAsync();
        }
    }
}
