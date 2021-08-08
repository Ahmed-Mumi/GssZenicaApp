using GssZenicaApp.Interfaces;
using GssZenicaApp.Repositories;
using System.Threading.Tasks;

namespace GssZenicaApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IMembershipFeeCategory MembershipFeeCategoryRepository => new MembershipFeeCategoryRepository(_context);
        public IMember MemberRepository => new MemberRepository(_context);
        public IReport ReportRepository => new ReportRepository(_context);
        public IEquipment EquipmentRepository => new EquipmentRepository(_context);
        public ISkill SkillRepository => new SkillRepository(_context);
        public IBorrowed BorrowedRepository => new BorrowedRepository(_context);
        public IStationActivity StationActivityRepository => new StationActivityRepository(_context);
        public IActivityMember ActivityMemberRepository => new ActivityMemberRepository(_context);
        public IMembershipFee MembershipFeeRepository => new MembershipFeeRepository(_context);
        public IStock StockRepository => new StockRepository(_context);
        public IEquipmentCategory EquipmentCategoryRepository => new EquipmentCategoryRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
