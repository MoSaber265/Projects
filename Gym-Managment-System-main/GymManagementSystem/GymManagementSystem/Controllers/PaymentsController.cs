using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly GymDbContext _context;
        public PaymentsController(GymDbContext context) { _context = context; }

        // 1. عرض كل المدفوعات مع بيانات العضو
        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments.Include(p => p.Member).ToListAsync();
            return View(payments);
        }

        // 2. صفحة إضافة دفع جديد
        public IActionResult Create()
        {
            ViewBag.Members = new SelectList(_context.Members, "MemberID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment paymentObj) // تغيير الاسم لـ paymentObj
        {
            ModelState.Remove("Member");

            if (ModelState.IsValid)
            {
                _context.Add(paymentObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Members = new SelectList(_context.Members, "MemberID", "Name", paymentObj.MemberID);
            return View(paymentObj);
        }

        // 4. صفحة تأكيد الحذف
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payments
                .Include(p => p.Member)
                .FirstOrDefaultAsync(m => m.PaymentID == id);

            if (payment == null) return NotFound();

            return View(payment);
        }

        // 5. تنفيذ الحذف الفعلي
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // نبحث بالـ PaymentID لضمان حذف السجل الصحيح
            var payment = await _context.Payments
                .FirstOrDefaultAsync(m => m.PaymentID == id);

            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}