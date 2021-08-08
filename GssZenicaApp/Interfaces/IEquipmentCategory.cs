using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IEquipmentCategory
    {
        void AddEquipmentCategory(EquipmentCategory equipmentCategory);
        void UpdateEquipmentCategory(EquipmentCategory equipmentCategory);
        Task DeleteEquipmentCategory(int id);
        Task<EquipmentCategory> GetEquipmentCategory(int id);
        Task<IEnumerable<EquipmentCategory>> GetAllEquipmentCategories();
    }
}
