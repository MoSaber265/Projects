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

        // 1. Index: عرض المدربين بترتيب أبجدي
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trainers.OrderBy(t => t.Name).ToListAsync());
        }

        // 2. Create (GET)
        public IActionResult Create() => View();

        // 3. Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer trainer)
        {
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

        // 4. Edit (GET): فتح صفحة التعديل
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null) return NotFound();

            return View(trainer);
        }

        // 5. Edit (POST): حفظ التعديلات
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trainer trainer)
        {
            if (id != trainer.TrainerID) return NotFound();

            ModelState.Remove("WorkSchedules");
            ModelState.Remove("WorkoutPlans");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerExists(trainer.TrainerID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        // 6. Delete (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var trainer = await _context.Trainers
                .FirstOrDefaultAsync(m => m.TrainerID == id);

            if (trainer == null) return NotFound();

            return View(trainer);
        }

        // 7. Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.TrainerID == id);

            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
            return _context.Trainers.Any(e => e.TrainerID == id);
        }
    }
}