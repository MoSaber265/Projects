using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class WorkSchedulesController : Controller
    {
        private readonly GymDbContext _context;
        public WorkSchedulesController(GymDbContext context) { _context = context; }

        // 1. Index
        public async Task<IActionResult> Index()
        {
            var schedules = await _context.WorkSchedules
                .Include(w => w.Trainer)
                .Include(w => w.WorkoutPlan)
                .OrderBy(w => w.ScheduleDate)
                .ThenBy(w => w.StartTime)
                .ToListAsync();
            return View(schedules);
        }

        // 2. Create (GET)
        public IActionResult Create()
        {
            PopulateDropDowns();
            return View();
        }

        // 3. Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkSchedule schedule)
        {
            ValidateScheduleTime(schedule);

            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDowns(schedule.TrainerID, schedule.PlanID);
            return View(schedule);
        }

        // 4. Edit (GET) - جديد
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var schedule = await _context.WorkSchedules.FindAsync(id);
            if (schedule == null) return NotFound();

            PopulateDropDowns(schedule.TrainerID, schedule.PlanID);
            return View(schedule);
        }

        // 5. Edit (POST) - جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkSchedule schedule)
        {
            if (id != schedule.ScheduleID) return NotFound();

            ValidateScheduleTime(schedule);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDowns(schedule.TrainerID, schedule.PlanID);
            return View(schedule);
        }

        // 6. Delete (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var workSchedule = await _context.WorkSchedules
                .Include(w => w.Trainer)
                .Include(w => w.WorkoutPlan)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);

            if (workSchedule == null) return NotFound();
            return View(workSchedule);
        }

        // 7. Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workSchedule = await _context.WorkSchedules.FindAsync(id);
            if (workSchedule != null)
            {
                _context.WorkSchedules.Remove(workSchedule);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // --- ميثودز مساعدة (Private Methods) ---

        private void PopulateDropDowns(object? selectedTrainer = null, object? selectedPlan = null)
        {
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name", selectedTrainer);
            ViewBag.Plans = new SelectList(_context.WorkoutPlans, "PlanID", "PlanName", selectedPlan);
        }

        private void ValidateScheduleTime(WorkSchedule schedule)
        {
            ModelState.Remove("Trainer");
            ModelState.Remove("WorkoutPlan");

            if (schedule.EndTime <= schedule.StartTime)
            {
                ModelState.AddModelError("EndTime", "End time must be after start time.");
            }
        }

        private bool ScheduleExists(int id) => _context.WorkSchedules.Any(e => e.ScheduleID == id);
    }
}