using System;

namespace GssZenicaApp.Models
{
    public class StationActivity
    {
        public int Id { get; set; }
        public DateTime DateOfActivity { get; set; }
        public DateTime? DateOfActivityTo { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Report Report { get; set; }
        public int? ReportId { get; set; }
    }
}
