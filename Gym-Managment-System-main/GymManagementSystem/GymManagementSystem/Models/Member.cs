using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty; // Initialized to avoid CS8618

        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public int MembershipID { get; set; }

        [ForeignKey("MembershipID")]
        public virtual Membership? Membership { get; set; } // Mark as nullable

        public virtual ICollection<MemberWorkoutPlan> MemberWorkoutPlans { get; set; } = new List<MemberWorkoutPlan>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}