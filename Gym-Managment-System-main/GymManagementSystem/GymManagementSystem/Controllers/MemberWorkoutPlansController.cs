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
        public MemberWorkoutPlansController(GymDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var data = await _context.MemberWorkoutPlans
                .Include(m => m.Member)
                .Include(m => m.WorkoutPlan)
                .ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Members = new SelectList(_context.Members, "MemberID", "Name");
            // تأكد أن موديل WorkoutPlan فيه PlanID و PlanName (أو غيرهم حسب الموديل عندك)
            ViewBag.Plans = new SelectList(_context.WorkoutPlans, "PlanID", "PlanName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberWorkoutPlan mPlan)
        {
            // شلنا العلاقات من الـ Validation عشان الـ ModelState.IsValid تطلع True
            ModelState.Remove("Member");
            ModelState.Remove("WorkoutPlan");

            if (ModelState.IsValid)
            {
                _context.Add(mPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Members = new SelectList(_context.Members, "MemberID", "Name", mPlan.MemberID);
            ViewBag.Plans = new SelectList(_context.WorkoutPlans, "PlanID", "PlanName", mPlan.PlanID);
            return View(mPlan);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mPlan = await _context.MemberWorkoutPlans
                .Include(m => m.Member)
                .Include(m => m.WorkoutPlan)
                .FirstOrDefaultAsync(m => m.Id == id); // البحث بالـ Id اللي عليه الـ [Key]

            if (mPlan == null) return NotFound();

            return View(mPlan);
        }

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
    }
}