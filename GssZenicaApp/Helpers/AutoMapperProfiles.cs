using AutoMapper;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;

namespace GssZenicaApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MembershipFeeCategory, ListMembershipFeeCategoryViewModel>();
            CreateMap<AddMembershipFeeCategoryViewModel, MembershipFeeCategory>();
            CreateMap<EditMembershipFeeCategoryViewModel, MembershipFeeCategory>().ReverseMap();

            CreateMap<Member, ListMemberViewModel>()
                .ForMember(x => x.BloodTypeName, m => m.MapFrom(b => b.BloodType.Label));
            CreateMap<AddMemberViewModel, Member>()
                .ForMember(x => x.FullName, m => m.MapFrom(f => f.FirstName + " " + f.LastName));
            CreateMap<EditMemberViewModel, Member>()
                .ForMember(x => x.FullName, m => m.MapFrom(f => f.FirstName + " " + f.LastName))
                .ReverseMap();

            CreateMap<Report, ListReportViewModel>()
                .ForMember(x => x.MemberName, m => m.MapFrom(f => f.Member.FullName));
            CreateMap<AddReportViewModel, Report>();
            CreateMap<EditReportViewModel, Report>().ReverseMap();

            CreateMap<Equipment, ListEquipmentViewModel>()
                .ForMember(x => x.EquipmentCategoryName, m => m.MapFrom(f => f.EquipmentCategory.Name))
                .ForMember(x => x.MemberPurchased, m => m.MapFrom(f => f.MemberPurchased.FullName));
            CreateMap<AddEquipmentViewModel, Equipment>();
            CreateMap<EditEquipmentViewModel, Equipment>().ReverseMap()
                .ForMember(x => x.OldQuantity, m => m.MapFrom(f => f.EquipmentCategory.Stock.LiveQuantity))
                .ForMember(x => x.Quantity, m => m.MapFrom(f => f.EquipmentCategory.Stock.LiveQuantity));

            CreateMap<Member, ListSkillViewModel>()
               .ForMember(x => x.DivingCategoryName, m => m.MapFrom(f => f.Skill.DivingCategory.Label))
               .ForMember(x => x.GuideCategoryName, m => m.MapFrom(f => f.Skill.GuideCategory.Label))
               .ForMember(x => x.SarCategoryName, m => m.MapFrom(f => f.Skill.SarCategory.Label))
               .ForMember(x => x.SkiingCategoryName, m => m.MapFrom(f => f.Skill.SkiingCategory.Label))
               .ForMember(x => x.Helio, m => m.MapFrom(f => f.Skill.Helio))
               .ForMember(x => x.Speleo, m => m.MapFrom(f => f.Skill.Speleo))
               .ForMember(x => x.PhtcItls, m => m.MapFrom(f => f.Skill.PhtcItls))
               .ForMember(x => x.MedicalCourse, m => m.MapFrom(f => f.Skill.MedicalCourse))
               .ForMember(x => x.SummerCourse, m => m.MapFrom(f => f.Skill.SummerCourse))
               .ForMember(x => x.WinterCourse, m => m.MapFrom(f => f.Skill.WinterCourse))
               .ForMember(x => x.Rescurer, m => m.MapFrom(f => f.Skill.Rescurer))
               .ForMember(x => x.MemberName, m => m.MapFrom(f => f.FullName));
            CreateMap<AddSkillViewModel, Skill>();
            CreateMap<EditSkillViewModel, Skill>().ReverseMap();

            CreateMap<StationActivity, ListStationActivityViewModel>();
            CreateMap<AddStationActivityViewModel, StationActivity>();
            CreateMap<EditStationActivityViewModel, StationActivity>().ReverseMap();

            CreateMap<MembershipFee, ListMembershipFeeViewModel>()
                .ForMember(x => x.MemberName, m => m.MapFrom(f => f.Member.FullName))
                .ForMember(x => x.MembershipFeeCategoryName, m => m.MapFrom(f => f.MembershipFeeCategory.Name))
                .ForMember(x => x.Amount, m => m.MapFrom(f => f.MembershipFeeCategory.Amount));
            CreateMap<AddMembershipFeeViewModel, MembershipFee>();

            CreateMap<EquipmentCategory, ListEquipmentCategoryViewModel>()
                .ForMember(x => x.StockQuantity, m => m.MapFrom(f => f.Stock.LiveQuantity));
            CreateMap<AddEquipmentCategoryViewModel, EquipmentCategory>();
            CreateMap<EditEquipmentCategoryViewModel, EquipmentCategory>().ReverseMap();

            CreateMap<Borrowed, ListBorrowedViewModel>()
                .ForMember(x => x.EquipmentCategoryName, m => m.MapFrom(f => f.EquipmentCategory.Name))
                .ForMember(x => x.DateOfBorrow, m => m.MapFrom(f => f.DateOfBorrow.ToString("dd/MM/yyyy")))
                .ForMember(x => x.MemberName, m => m.MapFrom(f => f.Member.FullName));
        }
    }
}
