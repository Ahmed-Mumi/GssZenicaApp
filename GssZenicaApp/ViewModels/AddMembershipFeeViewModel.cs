using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GssZenicaApp.ViewModels
{
    public class AddMembershipFeeViewModel
    {
        public DateTime DateOfFee { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public int MemberId { get; set; }
        public int MembershipFeeCategoryId { get; set; }

        public SelectList MemberList { get; set; }
        public SelectList MembershipFeeCategoryList { get; set; }
    }
}
