namespace GssZenicaApp.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public bool PhtcItls { get; set; }
        public bool Helio { get; set; }
        public bool Speleo { get; set; }
        public bool SummerCourse { get; set; }
        public bool WinterCourse { get; set; }
        public bool MedicalCourse { get; set; }
        public bool Rescurer { get; set; }
        public SkiingCategory SkiingCategory { get; set; }
        public int? SkiingCategoryId { get; set; }
        public DivingCategory DivingCategory { get; set; }
        public int? DivingCategoryId { get; set; }
        public GuideCategory GuideCategory { get; set; }
        public int? GuideCategoryId { get; set; }
        public SarCategory SarCategory { get; set; }
        public int? SarCategoryId { get; set; }
    }
}
