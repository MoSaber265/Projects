using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly GymDbContext _context;
        public MembersController(GymDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var members = await _context.Members
                .Include(m => m.Membership)
                .ToListAsync();
            return View(members);
        }

        public IActionResult Create()
        {
            // التصحيح هنا: لازم نستخدم MembershipID و MembershipName (أو النوع المتاح عندك)
            // تأكد من أسماء الأعمدة في جدول Membership (غالباً MembershipID و Type)
            ViewBag.MembershipList = new SelectList(_context.Memberships, "MembershipID", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member memberObj)
        {
            // حذف التحقق من العلاقات لمنع الـ Validation Error
            ModelState.Remove("Membership");
            ModelState.Remove("MemberWorkoutPlans");
            ModelState.Remove("Payments");

            if (ModelState.IsValid)
            {
                _context.Add(memberObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // التصحيح هنا أيضاً: استخدام الاسم الصحيح MembershipID
            ViewBag.MembershipList = new SelectList(_context.Memberships, "MembershipID", "Type", memberObj.MembershipID);
            return View(memberObj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var member = await _context.Members
                .Include(m => m.Membership)
                .FirstOrDefaultAsync(m => m.MemberID == id);

            if (member == null) return NotFound();

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}