// Program.cs
// نقطة انطلاق التطبيق وإعداد الـ Services
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// إضافة MVC
builder.Services.AddControllersWithViews();

// ربط الـ Database Context بـ SQL Server
builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// إعدادات الـ Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// الـ Route الافتراضي
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
