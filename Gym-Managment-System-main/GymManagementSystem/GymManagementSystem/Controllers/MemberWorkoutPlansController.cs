using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagementSystem.Controllers
{
    public class MemberWorkoutPlansController : Controller
    {
        private readonly GymDbContext _context;

        public MemberWorkoutPlansController(GymDbContext context)
        {
            _context = context;
        }

        // 1. عرض كل التخصيصات (Index)
        public async Task<IActionResult> Index()
        {
            var data = await _context.MemberWorkoutPlans
                .Include(m => m.Member)
                .Include(m => m.WorkoutPlan)
                .ToListAsync();
            return View(data);
        }

        // 2. إضافة تخصيص جديد (Create)
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberWorkoutPlan mPlan)
        {
            // إزالة التحقق من كائنات الـ Navigation لمنع الأخطاء الوهمية
            ModelState.Remove("Member");
            ModelState.Remove("WorkoutPlan");

            if (ModelState.IsValid)
            {
                _context.Add(mPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateDropDowns(mPlan.MemberID, mPlan.PlanID);
            return View(mPlan);
        }

        // 3. تعديل تخصيص موجود (Edit - GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var mPlan = await _context.MemberWorkoutPlans.FindAsync(id);
            if (mPlan == null) return NotFound();

            PopulateDropDowns(mPlan.MemberID, mPlan.PlanID);
            return View(mPlan);
        }

        // 4. حفظ التعديلات (Edit - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MemberWorkoutPlan mPlan)
        {
            if (id != mPlan.Id) return NotFound();

            ModelState.Remove("Member");
            ModelState.Remove("WorkoutPlan");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(mPlan.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateDropDowns(mPlan.MemberID, mPlan.PlanID);
            return View(mPlan);
        }

        // 5. صفحة تأكيد الحذف (Delete - GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mPlan = await _context.MemberWorkoutPlans
                .Include(m => m.Member)
                .Include(m => m.WorkoutPlan)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mPlan == null) return NotFound();

            return View(mPlan);
        }

        // 6. تنفيذ الحذف (Delete - POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mPlan = await _context.MemberWorkoutPlans.FindAsync(id);
            if (mPlan != null)
            {
                _context.MemberWorkoutPlans.Remove(mPlan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // --- ميثود مساعدة لتعبئة القوائم المنسدلة ---
        private void PopulateDropDowns(object? selectedMember = null, object? selectedPlan = null)
        {
            ViewBag.Members = new SelectList(_context.Members, "MemberID", "Name", selectedMember);
            // تأكد أن موديل WorkoutPlan يحتوي على PlanID و PlanName
            ViewBag.Plans = new SelectList(_context.WorkoutPlans, "PlanID", "PlanName", selectedPlan);
        }

        private bool Exists(int id) => _context.MemberWorkoutPlans.Any(e => e.Id == id);
    }
}