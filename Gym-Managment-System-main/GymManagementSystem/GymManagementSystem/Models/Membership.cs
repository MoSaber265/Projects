using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GymManagementSystem.Models
{
    public class Membership
    {
        [Key]
        // نصيحة: سميه MembershipID عشان EF يفهمه أوتوماتيك كـ Identity
        public int MemberShip { get; set; }

        [Required(ErrorMessage = "Please enter the membership type (e.g. Monthly, Yearly)")]
        [MaxLength(50)]
        [Display(Name = "Plan Type")]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Range(1, 365, ErrorMessage = "Duration must be between 1 and 365 days")]
        public int Duration { get; set; }

        [Required]
        [DataType(DataType.Currency)] // بيساعد في عرض العملة بشكل صح في الـ View
        [Range(0, 99999.99)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // استخدام virtual بيسمح بـ Lazy Loading وده أحسن للأداء
        // والـ new List بيمنع الـ NullReferenceException لو حاولت تضيف أعضاء للباقة
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}