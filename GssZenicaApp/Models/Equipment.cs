using System;

namespace GssZenicaApp.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsForUsage { get; set; } = true;
        public bool IsAvailable { get; set; } = true;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; } = 0;
        public DateTime? DateOfPurchase { get; set; }
        public string LocationOfPurchase { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Member MemberPurchased { get; set; }
        public int? MemberPurchasedId { get; set; }
        public string ReceiptImage { get; set; }
        public EquipmentCategory EquipmentCategory { get; set; }
        public int EquipmentCategoryId { get; set; }
        public decimal Length { get; set; }
        public decimal Thickness { get; set; }
        public bool IsCut { get; set; } = false;
        public bool IsRope { get; set; } = false;
    }
}
