using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IReport
    {
        void AddReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(int id);
        Task<Report> GetReport(int id);
        Task<IEnumerable<Report>> GetAllReports();
        //Task<Report> GetReportByStationActivity(int id);
    }
}
