using System;

namespace GssZenicaApp.ViewModels
{
    public class ListBorrowedViewModel
    {
        public int Id { get; set; }
        public string BorrowNumber { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public DateTime DateOfNecessaryReturn { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string UserName { get; set; }
        public string EquipmentCategoryName { get; set; }
        public int EquipmentCategoryId { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public string MemberName { get; set; }
        public int Quantity { get; set; }
    }
}
