using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    [Table("Trainers")]
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }

        [Required(ErrorMessage = "Trainer name is required")]
        [MaxLength(100)]
        [Display(Name = "Trainer Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(20)]
        [Phone] // بيتأكد إن التنسيق رقم تليفون
        public string Phone { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Specialization / Expertise")]
        public string Specialization { get; set; } = string.Empty;

        [Range(0, 100000)] // تأمين عشان مفيش مرتب بالسالب
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        // استخدام ? يجعل العلاقات Nullable عشان الـ Validation ميعطلش الـ Create
        public ICollection<WorkSchedule>? WorkSchedules { get; set; } = new List<WorkSchedule>();
        public ICollection<WorkoutPlan>? WorkoutPlans { get; set; } = new List<WorkoutPlan>();
    }
}