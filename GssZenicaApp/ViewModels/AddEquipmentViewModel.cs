using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GssZenicaApp.ViewModels
{
    public class AddEquipmentViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsForUsage { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public string LocationOfPurchase { get; set; }
        public string UserId { get; set; }
        public int MemberPurchasedId { get; set; }
        public string ReceiptImage { get; set; }
        public int EquipmentCategoryId { get; set; }
        public int? RopeId { get; set; }
        public int Quantity { get; set; }
        public int OldQuantity { get; set; }

        public SelectList MemberList { get; set; }
        public SelectList EquipmentCategoryList { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
