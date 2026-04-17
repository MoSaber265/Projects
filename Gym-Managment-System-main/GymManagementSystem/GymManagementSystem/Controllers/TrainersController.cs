using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class TrainersController : Controller
    {
        private readonly GymDbContext _context;
        public TrainersController(GymDbContext context) { _context = context; }

        // Index: عرض المدربين بترتيب أبجدي أو حسب الراتب (اختياري)
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trainers.OrderBy(t => t.Name).ToListAsync());
        }

        // Create (GET)
        public IActionResult Create() => View();

        // Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            // شلنا الـ Collections من حسابات الـ Validation عشان الفورم تتبعت صح
            ModelState.Remove("WorkSchedules");
            ModelState.Remove("WorkoutPlans");

            if (ModelState.IsValid)
            {
                _context.Add(trainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        // Delete (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var trainer = await _context.Trainers
                .FirstOrDefaultAsync(m => m.TrainerID == id);

            if (trainer == null) return NotFound();

            return View(trainer);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // استخدام FirstOrDefaultAsync هنا أضمن أحياناً من FindAsync في علاقات الجداول
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.TrainerID == id);

            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}