using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GssZenicaApp.ViewModels
{
    public class AddReportViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int MemberId { get; set; }
        public DateTime DateOfReport { get; set; }
        public DateTime DateOfActivity { get; set; }
        public string Location { get; set; }
        public string UserId { get; set; }
        public int StationActivityId { get; set; }

        public SelectList MemberList { get; set; }
    }
}
