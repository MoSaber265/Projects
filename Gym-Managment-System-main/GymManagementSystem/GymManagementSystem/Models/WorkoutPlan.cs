using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    public class WorkoutPlan
    {
        [Key]
        public int PlanID { get; set; } // PK

        [Required(ErrorMessage = "Plan Name is required")]
        [MaxLength(100)]
        [Display(Name = "Plan Name")]
        public string PlanName { get; set; } = string.Empty;

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Range(1, 5, ErrorMessage = "Difficulty must be between 1 and 5")]
        [Display(Name = "Difficulty Level")]
        public int DifficultyLevel { get; set; }

        // ربط الخطة بمدرب معين (الذي صمم الخطة)
        [Required]
        public int TrainerID { get; set; }

        [ForeignKey("TrainerID")]
        public Trainer? Trainer { get; set; }

        // لضمان عدم حدوث Error عند التعامل مع القوائم، بنعملها Initialize
        public ICollection<MemberWorkoutPlan> MemberWorkoutPlans { get; set; } = new List<MemberWorkoutPlan>();

        public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
    }
}