using System;

namespace GssZenicaApp.Models
{
    public class MembershipFee
    {
        public int Id { get; set; }
        public DateTime DateOfFee { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public MembershipFeeCategory MembershipFeeCategory { get; set; }
        public int MembershipFeeCategoryId { get; set; }
    }
}
