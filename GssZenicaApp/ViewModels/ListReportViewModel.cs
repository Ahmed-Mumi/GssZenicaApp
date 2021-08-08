using System;

namespace GssZenicaApp.ViewModels
{
    public class ListReportViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string MemberName { get; set; }
        public DateTime DateOfReport { get; set; }
        public string UserName { get; set; }
    }
}
