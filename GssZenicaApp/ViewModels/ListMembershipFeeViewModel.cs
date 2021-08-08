using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.ViewModels
{
    public class ListMembershipFeeViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfFee { get; set; }
        public string MemberName { get; set; }
        public string MembershipFeeCategoryName { get; set; }
        public decimal Amount { get; set; }
    }
}
