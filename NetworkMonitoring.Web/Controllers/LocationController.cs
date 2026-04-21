using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Linq;

namespace NetworkMonitoring.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;
        public LocationController(AppDbContext ctx) { _context = ctx; }
        public IActionResult Index() => View(_context.Locations.Where(l => !l.Suspend).ToList());
        public IActionResult Create() { ViewBag.Countries = _context.Countries.Where(c => !c.Suspend).ToList(); return View(new Location()); }
        [HttpPost] public IActionResult Create(Location model) { if (ModelState.IsValid) { _context.Locations.Add(model); _context.SaveChanges(); return RedirectToAction("Index"); } ViewBag.Countries = _context.Countries.ToList(); return View(model); }
        public IActionResult Edit(int id) { var m = _context.Locations.Find(id); if (m == null) return NotFound(); ViewBag.Countries = _context.Countries.ToList(); return View(m); }
        [HttpPost] public IActionResult Edit(Location model) { if (ModelState.IsValid) { _context.Locations.Update(model); _context.SaveChanges(); return RedirectToAction("Index"); } ViewBag.Countries = _context.Countries.ToList(); return View(model); }
        public IActionResult Delete(int id) { var m = _context.Locations.Find(id); if (m == null) return NotFound(); m.Suspend = true; _context.SaveChanges(); return RedirectToAction("Index"); }
    }
}
