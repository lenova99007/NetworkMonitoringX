using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Linq;
namespace NetworkMonitoring.Web.Controllers
{
    public class ActivityTypesController : Controller
    {
        private readonly AppDbContext _context;
        public ActivityTypesController(AppDbContext ctx) { _context = ctx; }
        public IActionResult Index() => View(_context.ActivityTypes.Where(a => !a.Suspend).ToList());
        public IActionResult Create() => View(new ActivityType());
        [HttpPost] public IActionResult Create(ActivityType model) { if (ModelState.IsValid) { _context.ActivityTypes.Add(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Edit(int id) { var m = _context.ActivityTypes.Find(id); if (m == null) return NotFound(); return View(m); }
        [HttpPost] public IActionResult Edit(ActivityType model) { if (ModelState.IsValid) { _context.ActivityTypes.Update(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Delete(int id) { var m = _context.ActivityTypes.Find(id); if (m == null) return NotFound(); m.Suspend = true; _context.SaveChanges(); return RedirectToAction("Index"); }
    }
}
