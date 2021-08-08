namespace GssZenicaApp.ViewModels
{
    public class ListMemberViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodTypeName { get; set; }
        public string MemberTypeName { get; set; }
        public string MemberPositionName { get; set; }
        public bool IsChecked { get; set; }
        public bool IsDebt { get; set; }
        public int PresenceCounter { get; set; } = 0;
        public int SkillId { get; set; }
    }
}
