using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Linq;

namespace NetworkMonitoring.Web.Controllers
{
    public class DevicesController : Controller
    {
        private readonly AppDbContext _context;
        public DevicesController(AppDbContext ctx) { _context = ctx; }
        public IActionResult Index() => View(_context.Devices.Where(d => !d.Suspend).ToList());
        public IActionResult Create() { ViewBag.Types = _context.DeviceTypes.Where(t => !t.Suspend).ToList(); ViewBag.Locations = _context.Locations.Where(l => !l.Suspend).ToList(); return View(new Device()); }
        [HttpPost] public IActionResult Create(Device model) { if (ModelState.IsValid) { _context.Devices.Add(model); _context.SaveChanges(); return RedirectToAction("Index"); } ViewBag.Types = _context.DeviceTypes.ToList(); ViewBag.Locations = _context.Locations.ToList(); return View(model); }
        public IActionResult Edit(int id) { var m = _context.Devices.Find(id); if (m == null) return NotFound(); ViewBag.Types = _context.DeviceTypes.ToList(); ViewBag.Locations = _context.Locations.ToList(); return View(m); }
        [HttpPost] public IActionResult Edit(Device model) { if (ModelState.IsValid) { _context.Devices.Update(model); _context.SaveChanges(); return RedirectToAction("Index"); } ViewBag.Types = _context.DeviceTypes.ToList(); ViewBag.Locations = _context.Locations.ToList(); return View(model); }
        public IActionResult Delete(int id) { var m = _context.Devices.Find(id); if (m == null) return NotFound(); m.Suspend = true; _context.SaveChanges(); return RedirectToAction("Index"); }
    }
}
