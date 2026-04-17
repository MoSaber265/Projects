using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    public class WorkSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Session Date")]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        [Range(1, 20, ErrorMessage = "Hall number must be between 1 and 20")]
        public int Hall { get; set; }

        [Required]
        public int TrainerID { get; set; }

        [ForeignKey("TrainerID")]
        public Trainer? Trainer { get; set; }

        [Required]
        public int PlanID { get; set; }

        [ForeignKey("PlanID")]
        public WorkoutPlan? WorkoutPlan { get; set; }
    }
}