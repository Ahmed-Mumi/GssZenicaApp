using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GssZenicaApp.ViewModels
{
    public class AddMemberViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsDebt { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? BloodTypeId { get; set; }
        public int MemberTypeId { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
        public string UserId { get; set; }
        public int MemberPositionId { get; set; }

        public SelectList GenderList { get; set; }
        public SelectList BloodTypeList { get; set; }
        public SelectList MemberTypeList { get; set; }
        public SelectList CityList { get; set; }
        public SelectList MemberPositionList { get; set; }
    }
}
