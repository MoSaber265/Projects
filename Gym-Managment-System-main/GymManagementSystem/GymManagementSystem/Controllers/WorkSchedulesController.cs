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

        // 1. عرض الجدول الزمني مع اسم المدرب واسم التمرين
        public async Task<IActionResult> Index()
        {
            var schedules = await _context.WorkSchedules
                .Include(w => w.Trainer)
                .Include(w => w.WorkoutPlan) // ضروري لعرض اسم التمرين
                .OrderBy(w => w.ScheduleDate)
                .ThenBy(w => w.StartTime)
                .ToListAsync();
            return View(schedules);
        }

        // 2. صفحة إضافة موعد (GET)
        public IActionResult Create()
        {
            // نبعت قائمة المدربين والخطط عشان اليوزر يختار منهم
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name");
            ViewBag.Plans = new SelectList(_context.WorkoutPlans, "PlanID", "PlanName");
            return View();
        }

        // 3. حفظ الموعد (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkSchedule schedule)
        {
            // تنظيف الـ Validation من الـ Navigation Properties
            ModelState.Remove("Trainer");
            ModelState.Remove("WorkoutPlan");

            // Logic بسيط: تأكد إن وقت النهاية بعد وقت البداية
            if (schedule.EndTime <= schedule.StartTime)
            {
                ModelState.AddModelError("EndTime", "End time must be after start time.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // إعادة مليء القوائم في حالة وجود خطأ
            ViewBag.Trainers = new SelectList(_context.Trainers, "TrainerID", "Name", schedule.TrainerID);
            ViewBag.Plans = new SelectList(_context.WorkoutPlans, "PlanID", "PlanName", schedule.PlanID);
            return View(schedule);
        }

        // 4. صفحة التأكيد (GET)
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

        // 5. الحذف الفعلي (POST)
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
    }
}