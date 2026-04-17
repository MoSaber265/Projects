using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Data;
using System.Linq;

namespace GymManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly GymDbContext _context;

        public HomeController(GymDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 1. حساب عدد المدربين
            ViewBag.TrainersCount = _context.Trainers.Count();

            // 2. حساب عدد المشتركين
            ViewBag.MembersCount = _context.Members.Count();

            // 3. حساب عدد خطط الاشتراك المتاحة
            ViewBag.PlansCount = _context.Memberships.Count();

            // 4. حساب إجمالي الإيرادات
            ViewBag.TotalRevenue = _context.Payments.Any() ? _context.Payments.Sum(p => p.Amount) : 0;

            return View();
        }

        // الأكشن ده هو اللي كان ناقص يا محمد
        public IActionResult Privacy()
        {
            return View();
        }
    }
}