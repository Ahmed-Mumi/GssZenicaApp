using System;

namespace GssZenicaApp.ViewModels
{
    public class ListEquipmentViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool IsForUsage { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public string ReceiptImage { get; set; }
        public string MemberPurchased { get; set; }
        public string EquipmentCategoryName { get; set; }
        public int? RopeId { get; set; }
    }
}
