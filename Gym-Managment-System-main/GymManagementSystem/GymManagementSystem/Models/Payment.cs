using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; } // PK

        [Required(ErrorMessage = "Please enter the payment amount")]
        [Range(0.01, 100000, ErrorMessage = "Amount must be greater than zero")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please select a payment method")]
        [MaxLength(50)]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, etc.

        [Display(Name = "Date of Payment")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public int MemberID { get; set; } // FK Member

        [ForeignKey("MemberID")]
        public Member? Member { get; set; } // Navigation property
    }
}