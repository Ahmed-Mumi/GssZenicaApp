using System;

namespace GssZenicaApp.ViewModels
{
    public class AddBorrowViewModel
    {
        public DateTime DateOfBorrow { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int EquipmentId { get; set; }
        public string Note { get; set; }
        public int MemberId { get; set; }
        public int Quantity { get; set; }
    }
}
