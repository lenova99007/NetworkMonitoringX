using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Shared.Data;
using System.Linq;

namespace NetworkMonitoring.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly AppDbContext _db;
        public ChatController(AppDbContext db) { _db = db; }

        public IActionResult Index(int withUserId = 0)
        {
            var me = int.Parse(User?.FindFirst("UserId")?.Value ?? "0"); // may be 0 in dev mode
            var msgs = _db.ChatMessages.OrderBy(m => m.CreatedAt).Take(200).ToList();
            return View(msgs);
        }
    }
}
