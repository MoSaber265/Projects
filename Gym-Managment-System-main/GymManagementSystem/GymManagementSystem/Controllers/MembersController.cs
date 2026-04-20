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

        // 1. عرض قائمة الأعضاء
        public async Task<IActionResult> Index()
        {
            var members = await _context.Members
                .Include(m => m.Membership)
                .ToListAsync();
            return View(members);
        }

        // 2. صفحة إضافة عضو جديد
        public IActionResult Create()
        {
            ViewBag.MembershipList = new SelectList(_context.Memberships, "MembershipID", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member memberObj)
        {
            // تنظيف الـ Validation من العلاقات المعقدة
            ModelState.Remove("Membership");
            ModelState.Remove("MemberWorkoutPlans");
            ModelState.Remove("Payments");

            if (ModelState.IsValid)
            {
                _context.Add(memberObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MembershipList = new SelectList(_context.Memberships, "MembershipID", "Type", memberObj.MembershipID);
            return View(memberObj);
        }

        // 3. صفحة تعديل عضو (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var member = await _context.Members.FindAsync(id);
            if (member == null) return NotFound();

            ViewBag.MembershipList = new SelectList(_context.Memberships, "MembershipID", "Type", member.MembershipID);
            return View(member);
        }

        // 4. حفظ تعديلات العضو (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member memberObj)
        {
            if (id != memberObj.MemberID) return NotFound();

            // نفس تنظيف الـ Validation عشان الـ Edit ميضربش
            ModelState.Remove("Membership");
            ModelState.Remove("MemberWorkoutPlans");
            ModelState.Remove("Payments");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberObj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(memberObj.MemberID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MembershipList = new SelectList(_context.Memberships, "MembershipID", "Type", memberObj.MembershipID);
            return View(memberObj);
        }

        // 5. صفحة تأكيد الحذف (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var member = await _context.Members
                .Include(m => m.Membership)
                .FirstOrDefaultAsync(m => m.MemberID == id);

            if (member == null) return NotFound();

            return View(member);
        }

        // 6. تنفيذ الحذف الفعلي (POST)
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

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.MemberID == id);
        }
    }
}