using System;

namespace GssZenicaApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public DateTime? DateOfLeaving { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDebt { get; set; } = false;
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public BloodType BloodType { get; set; }
        public int? BloodTypeId { get; set; }
        public MemberType MemberType { get; set; }
        public int MemberTypeId { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        //public City CityBorn { get; set; }
        //public int CityBornId { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public MemberPosition MemberPosition { get; set; }
        public int MemberPositionId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        public int PresenceCounter { get; set; } = 0;
    }
}
