using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Linq;

namespace NetworkMonitoring.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;
        public CountryController(AppDbContext ctx) { _context = ctx; }
        public IActionResult Index() => View(_context.Countries.Where(c => !c.Suspend).ToList());
        public IActionResult Create() => View(new Country());
        [HttpPost] public IActionResult Create(Country model) { if (ModelState.IsValid) { _context.Countries.Add(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Edit(int id) { var m = _context.Countries.Find(id); if (m == null) return NotFound(); return View(m); }
        [HttpPost] public IActionResult Edit(Country model) { if (ModelState.IsValid) { _context.Countries.Update(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Delete(int id) { var m = _context.Countries.Find(id); if (m == null) return NotFound(); m.Suspend = true; _context.SaveChanges(); return RedirectToAction("Index"); }
    }
}
