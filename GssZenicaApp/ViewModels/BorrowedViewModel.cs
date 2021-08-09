using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GssZenicaApp.ViewModels
{
    public class BorrowedViewModel
    {
        public IEnumerable<ListEquipmentCategoryViewModel> EquipmentCategoryList { get; set; }
        public SelectList MemberList { get; set; }
        public int? MemberId { get; set; }
        public int EquipmentId { get; set; }
    }
}
