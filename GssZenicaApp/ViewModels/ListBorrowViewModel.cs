using System;

namespace GssZenicaApp.ViewModels
{
    public class ListBorrowViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfBorrow { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string UserName { get; set; }
        public string EquipmentName { get; set; }
        public bool IsActive { get; set; }
        public string MemberName { get; set; }
        public int Quantity { get; set; }
    }
}
