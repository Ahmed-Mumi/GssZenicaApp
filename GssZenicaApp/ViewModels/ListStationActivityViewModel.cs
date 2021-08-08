using System;

namespace GssZenicaApp.ViewModels
{
    public class ListStationActivityViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfActivity { get; set; }
        public string Title { get; set; }
        public bool HasReport { get; set; }
        public int? ReportId { get; set; }
    }
}
