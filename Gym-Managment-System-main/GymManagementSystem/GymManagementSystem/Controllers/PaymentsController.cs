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
        public async Task<IActionResult> Create(Payment paymentObj)
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

        // --- 3. صفحة تعديل دفعة موجودة (جديد) ---
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();

            // إرسال قائمة الأعضاء مع تحديد العضو الحالي
            ViewBag.Members = new SelectList(_context.Members, "MemberID", "Name", payment.MemberID);
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payment paymentObj)
        {
            if (id != paymentObj.PaymentID) return NotFound();

            ModelState.Remove("Member");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentObj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(paymentObj.PaymentID)) return NotFound();
                    else throw;
                }
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
            var payment = await _context.Payments.FindAsync(id);

            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}