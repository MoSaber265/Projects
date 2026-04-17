using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    public class MemberWorkoutPlan
    {
        [Key]
        public int Id { get; set; }

        public int MemberID { get; set; }

        // تأكد أن هذا الاسم يطابق الـ PK في موديل WorkoutPlan (لو اسمه PlanID سيبه كدة)
        public int PlanID { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [ForeignKey("MemberID")]
        public Member? Member { get; set; }

        [ForeignKey("PlanID")]
        public WorkoutPlan? WorkoutPlan { get; set; }
    }
}