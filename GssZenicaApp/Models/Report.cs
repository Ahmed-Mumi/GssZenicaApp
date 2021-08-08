using System;

namespace GssZenicaApp.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public DateTime DateOfReport { get; set; } = DateTime.Now;
        public DateTime DateOfActivity { get; set; }
        public string Location { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public StationActivity StationActivity { get; set; }
        //public int StationActivityId { get; set; }
    }
}
