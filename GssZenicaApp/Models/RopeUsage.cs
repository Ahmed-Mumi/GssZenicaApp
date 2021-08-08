using System;

namespace GssZenicaApp.Models
{
    public class RopeUsage
    {
        public int Id { get; set; }
        public Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }
        public DateTime DateOfUsage { get; set; }
        public string Note { get; set; }
        public bool IsDamaged { get; set; } = false;
    }
}
