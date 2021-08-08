using GssZenicaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IBorrowed
    {
        void AddBorrow(Borrowed borrowed);
        void UpdateBorrow(Borrowed borrowed);
        Task DeleteBorrow(int id);
        Task<Borrowed> GetBorrow(int id);
        Task<IEnumerable<Borrowed>> GetAllBorrows();
        Task<IEnumerable<Borrowed>> GetAllActiveBorrows();
        Task<IEnumerable<Borrowed>> GetAllInactiveBorrows();
        Task<int> GetLastBorrowId();
        Task<IEnumerable<Borrowed>> GetMembersActiveBorrows(int memberId);
    }
}