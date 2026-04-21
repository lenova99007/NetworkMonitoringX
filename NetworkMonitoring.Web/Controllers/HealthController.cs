using Microsoft.AspNetCore.Mvc;
using System;

namespace NetworkMonitoring.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "Healthy", timestamp = DateTime.Now });
    }
}