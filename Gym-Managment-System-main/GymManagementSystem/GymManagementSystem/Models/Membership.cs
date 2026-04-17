using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GymManagementSystem.Models
{
    public class Membership
    {
        [Key]
        // الاسم ده (MemberShip) هو اللي هنستخدمه كـ Foreign Key في جدول الـ Member
        public int MemberShip { get; set; }

        [Required(ErrorMessage = "Please enter the membership type (e.g. Monthly, Yearly)")]
        [MaxLength(50)]
        [Display(Name = "Plan Type")]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Range(1, 365, ErrorMessage = "Duration must be between 1 and 365 days")]
        public int Duration { get; set; }

        [Required]
        [Range(0, 99999.99)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // استخدام ? لجعلها Nullable يمنع مشاكل الـ Validation عند إضافة باقة جديدة
        public ICollection<Member>? Members { get; set; }
    }
}