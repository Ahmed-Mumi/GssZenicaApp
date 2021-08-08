using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GssZenicaApp.ViewModels
{
    public class AddStationActivityViewModel
    {
        public DateTime DateOfActivity { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }

        public List<ListMemberViewModel> MemberList { get; set; }
    }
}
