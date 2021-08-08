using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IStationActivity
    {
        void AddStationActivity(StationActivity stationActivity);
        void UpdateStationActivity(StationActivity stationActivity);
        void DeleteStationActivity(int id);
        Task<StationActivity> GetStationActivity(int id);
        Task<IEnumerable<StationActivity>> GetAllStationActivities();

    }
}
