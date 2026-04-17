using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; // ضرورية للـ SelectList

namespace GymManagementSystem.Controllers
{
    public class WorkoutPlansController : Controller
    {
        private readonly GymDbContext _context;
        public WorkoutPlansController(GymDbContext context) { _context = context; }

        // 1. عرض الخطط مع اسم المدرب المرتبط بها
        public async Task<IActionResult> Index()
        {
            // استخدمنا Include عشان نجيب بيانات المدرب مع الخطة
            var plans = await _context.WorkoutPlans.Include(w => w.Trainer).ToListAsync();
            return View(plans);
        }

        // 2. صفحة الإضافة (GET)
        public IActionResult Create()
        {
            // بنبعت قائمة المدربين عشان تختار منهم في الـ View
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name");
            return View();
        }

        // 3. حفظ الخطة (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutPlan plan)
        {
            // بنشيل العلاقات من الـ ModelState عشان الـ Validation ينجح
            ModelState.Remove("Trainer");
            ModelState.Remove("MemberWorkoutPlans");
            ModelState.Remove("WorkSchedules");

            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // لو حصل خطأ بنرجع قائمة المدربين تاني عشان الفورم متبوظش
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name", plan.TrainerID);
            return View(plan);
        }

        // 4. صفحة الحذف (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var plan = await _context.WorkoutPlans
                .Include(w => w.Trainer) // عشان نعرض اسم المدرب في صفحة التأكيد
                .FirstOrDefaultAsync(m => m.PlanID == id);

            if (plan == null) return NotFound();

            return View(plan);
        }

        // 5. الحذف النهائي (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plan = await _context.WorkoutPlans.FindAsync(id);
            if (plan != null)
            {
                _context.WorkoutPlans.Remove(plan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}