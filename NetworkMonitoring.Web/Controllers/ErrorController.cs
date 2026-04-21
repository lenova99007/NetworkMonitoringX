using Microsoft.AspNetCore.Mvc;
namespace NetworkMonitoring.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Forbidden() => View("403");
    }
}
