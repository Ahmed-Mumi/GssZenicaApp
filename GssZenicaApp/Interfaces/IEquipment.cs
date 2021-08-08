using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IEquipment
    {
        void AddEquipment(Equipment equipment);
        void UpdateEquipment(Equipment equipment);
        void DeleteEquipment(int id);
        Task<Equipment> GetEquipment(int id);
        Task<IEnumerable<Equipment>> GetAllEquipments();
        Task<IEnumerable<EquipmentCategory>> GetAllEquipmentCategory();
    }
}
