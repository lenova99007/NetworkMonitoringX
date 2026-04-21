using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Linq;
namespace NetworkMonitoring.Web.Controllers
{
    public class EmailGroupsController : Controller
    {
        private readonly AppDbContext _context;
        public EmailGroupsController(AppDbContext ctx) { _context = ctx; }
        public IActionResult Index() => View(_context.EmailGroups.Where(e => !e.Suspend).ToList());
        public IActionResult Create() => View(new EmailGroup());
        [HttpPost] public IActionResult Create(EmailGroup model) { if (ModelState.IsValid) { _context.EmailGroups.Add(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Edit(int id) { var m = _context.EmailGroups.Find(id); if (m == null) return NotFound(); return View(m); }
        [HttpPost] public IActionResult Edit(EmailGroup model) { if (ModelState.IsValid) { _context.EmailGroups.Update(model); _context.SaveChanges(); return RedirectToAction("Index"); } return View(model); }
        public IActionResult Delete(int id) { var m = _context.EmailGroups.Find(id); if (m == null) return NotFound(); m.Suspend = true; _context.SaveChanges(); return RedirectToAction("Index"); }
    }
}
