using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;

namespace GymManagementSystem.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<MemberWorkoutPlan> MemberWorkoutPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. المفاتيح المركبة
            modelBuilder.Entity<WorkSchedule>()
                .HasKey(w => new { w.TrainerID, w.PlanID });

            modelBuilder.Entity<MemberWorkoutPlan>()
                .HasKey(m => new { m.MemberID, m.PlanID });

            // 2. علاقة العضو بالاشتراك
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Membership)
                .WithMany(ms => ms.Members)
                .HasForeignKey(m => m.MembershipID)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. علاقة خطة التمرين بالمدرب (مكتوبة مرة واحدة بس أهي)
            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(w => w.Trainer)
                .WithMany(t => t.WorkoutPlans)
                .HasForeignKey(w => w.TrainerID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}