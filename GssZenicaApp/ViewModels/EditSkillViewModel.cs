using Microsoft.AspNetCore.Mvc.Rendering;

namespace GssZenicaApp.ViewModels
{
    public class EditSkillViewModel
    {
        public int Id { get; set; }
        public bool PhtcItls { get; set; }
        public bool Helio { get; set; }
        public bool Speleo { get; set; }
        public bool SummerCourse { get; set; }
        public bool WinterCourse { get; set; }
        public bool MedicalCourse { get; set; }
        public bool Rescurer { get; set; }
        public int? SkiingCategoryId { get; set; }
        public int? DivingCategoryId { get; set; }
        public int? GuideCategoryId { get; set; }
        public int? SarCategoryId { get; set; }

        public SelectList SkiingCategoryList { get; set; }
        public SelectList DivingCategoryList { get; set; }
        public SelectList GuideCategoryList { get; set; }
        public SelectList SarCategoryList { get; set; }
    }
}
