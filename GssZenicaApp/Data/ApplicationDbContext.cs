using GssZenicaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GssZenicaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ActivityMember> ActivityMembers { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Borrowed> Borrows { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DivingCategory> DivingCategories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
        //public DbSet<EquipmentCategoryType> EquipmentCategoryTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GuideCategory> GuideCategories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberPosition> MemberPositions { get; set; }
        public DbSet<MembershipFee> MembershipFees { get; set; }
        public DbSet<MembershipFeeCategory> MembershipFeeCategories { get; set; }
        public DbSet<MemberType> MemberTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        //public DbSet<Rope> Ropes { get; set; }
        public DbSet<RopeUsage> RopeUsages { get; set; }
        public DbSet<SarCategory> SarCategories { get; set; }
        public DbSet<SkiingCategory> SkiingCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<StationActivity> StationActivities { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Borrowed>()
                .HasOne(c => c.Member)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EquipmentCategory>()
               .HasOne(a => a.Stock)
               .WithOne(b => b.EquipmentCategory)
               .HasForeignKey<Stock>(b => b.EquipmentCategoryId);

            //base.OnModelCreating(builder);
            //builder.Entity<Report>()
            //    .HasOne(c => c.StationActivity)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
