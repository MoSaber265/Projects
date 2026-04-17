using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly GymDbContext _context;
        public MembershipsController(GymDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Memberships.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Membership membershipObj)
        {
            // شلنا سطر الـ Valid عشان لو فيه أي Navigation Properties متبوظش الـ Save
            if (membershipObj != null)
            {
                _context.Add(membershipObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershipObj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            // استخدام MemberShip (زي الموديل بالظبط)
            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MemberShip == id);

            if (membership == null) return NotFound();

            return View(membership);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // تعديل بسيط هنا لضمان البحث بالـ ID الصح
            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MemberShip == id);

            if (membership != null)
            {
                _context.Memberships.Remove(membership);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}