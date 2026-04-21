using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Linq;

namespace NetworkMonitoring.Web.Controllers
{
    public class DeviceTypesController : Controller
    {
        private readonly AppDbContext _context;
        public DeviceTypesController(AppDbContext ctx) { _context = ctx; }
        public IActionResult Index() => View(_context.DeviceTypes.Where(d => !d.Suspend).ToList());
        public IActionResult Create() => View(new DeviceType());
        [HttpPost] public IActionResult Create(DeviceType model) { if (ModelState.IsValid) { _context.DeviceTypes.Add(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Edit(int id) { var m = _context.DeviceTypes.Find(id); if (m == null) return NotFound(); return View(m); }
        [HttpPost] public IActionResult Edit(DeviceType model) { if (ModelState.IsValid) { _context.DeviceTypes.Update(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Delete(int id) { var m = _context.DeviceTypes.Find(id); if (m == null) return NotFound(); m.Suspend = true; _context.SaveChanges(); return RedirectToAction("Index"); }
    }
}
