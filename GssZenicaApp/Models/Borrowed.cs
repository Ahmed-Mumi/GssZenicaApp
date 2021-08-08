using System;

namespace GssZenicaApp.Models
{
    public class Borrowed
    {
        public int Id { get; set; }
        public string BorrowNumber { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public DateTime DateOfNecessaryReturn { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public EquipmentCategory EquipmentCategory { get; set; }
        public int EquipmentCategoryId { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; } = true;
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public int Quantity { get; set; } = 0;

    }
}
