using System.Threading.Tasks;

namespace GssZenicaApp.Interfaces
{
    public interface IUnitOfWork
    {
        IMembershipFeeCategory MembershipFeeCategoryRepository { get; }
        IMember MemberRepository { get; }
        IReport ReportRepository { get; }
        IEquipment EquipmentRepository { get; }
        ISkill SkillRepository { get; }
        IBorrowed BorrowedRepository { get; }
        IStationActivity StationActivityRepository { get; }
        IActivityMember ActivityMemberRepository { get; }
        IMembershipFee MembershipFeeRepository { get; }
        IStock StockRepository { get; }
        IEquipmentCategory EquipmentCategoryRepository { get; }
        Task<bool> Complete();
    }
}
