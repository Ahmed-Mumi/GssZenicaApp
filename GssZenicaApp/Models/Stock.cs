namespace GssZenicaApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int LiveQuantity { get; set; } = 0;
        public int TotalQuantity { get; set; } = 0;
        public int TotalQuantityForUsage { get; set; } = 0;
        public EquipmentCategory EquipmentCategory { get; set; }
        public int EquipmentCategoryId { get; set; }
    }
}
