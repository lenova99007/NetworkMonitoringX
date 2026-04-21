using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using NetworkMonitoring.Web.Hubs;
using System.Linq;
using System.Threading.Tasks;
namespace NetworkMonitoring.Web.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _hub;
        public LogsController(AppDbContext ctx, IHubContext<ChatHub> hub) { _context = ctx; _hub = hub; }

        public IActionResult Index()
        {
            var model = _context.PingLogs.OrderByDescending(p => p.CreatedAt).Take(200).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResendPingAlert(int id)
        {
            var pl = _context.PingLogs.Find(id);
            if (pl == null) return NotFound();
            // simulate resend - broadcast via SignalR
            var alert = new LogAlertDto { DeviceName = pl.DeviceId.ToString(), LogType = "Ping", Message = pl.ResultMessage, Timestamp = pl.CreatedAt };
            await _hub.Clients.All.SendAsync("ReceiveLog", alert);
            return RedirectToAction("Index");
        }
    }
}
