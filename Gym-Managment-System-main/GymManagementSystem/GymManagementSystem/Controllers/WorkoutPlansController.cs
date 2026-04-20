using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagementSystem.Controllers
{
    public class WorkoutPlansController : Controller
    {
        private readonly GymDbContext _context;
        public WorkoutPlansController(GymDbContext context) { _context = context; }

        // 1. عرض الخطط مع اسم المدرب المرتبط بها
        public async Task<IActionResult> Index()
        {
            var plans = await _context.WorkoutPlans.Include(w => w.Trainer).ToListAsync();
            return View(plans);
        }

        // 2. صفحة الإضافة (GET)
        public IActionResult Create()
        {
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name");
            return View();
        }

        // 3. حفظ الخطة (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutPlan plan)
        {
            ModelState.Remove("Trainer");
            ModelState.Remove("MemberWorkoutPlans");
            ModelState.Remove("WorkSchedules");

            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name", plan.TrainerID);
            return View(plan);
        }

        // --- 4. صفحة التعديل (Edit - GET) ---
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var plan = await _context.WorkoutPlans.FindAsync(id);
            if (plan == null) return NotFound();

            // نبعت قائمة المدربين ونحدد المدرب اللي عامل الخطة دي حالياً
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name", plan.TrainerID);
            return View(plan);
        }

        // --- 5. حفظ التعديل (Edit - POST) ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkoutPlan plan)
        {
            if (id != plan.PlanID) return NotFound();

            ModelState.Remove("Trainer");
            ModelState.Remove("MemberWorkoutPlans");
            ModelState.Remove("WorkSchedules");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.PlanID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name", plan.TrainerID);
            return View(plan);
        }

        // 6. صفحة الحذف (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var plan = await _context.WorkoutPlans
                .Include(w => w.Trainer)
                .FirstOrDefaultAsync(m => m.PlanID == id);

            if (plan == null) return NotFound();

            return View(plan);
        }

        // 7. الحذف النهائي (POST)
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

        private bool PlanExists(int id) => _context.WorkoutPlans.Any(e => e.PlanID == id);
    }
}