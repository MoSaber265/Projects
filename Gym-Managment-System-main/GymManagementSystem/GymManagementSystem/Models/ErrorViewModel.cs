// ErrorViewModel.cs
// يستخدم لعرض معلومات الخطأ في صفحة Error
namespace GymManagementSystem.Models
{
    public class ErrorViewModel
    {
        // رقم الـ Request الخاص بالخطأ
        public string? RequestId { get; set; }

        // يرجع true لو الـ RequestId مش فاضي
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
