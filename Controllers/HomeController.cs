using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Services;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices] InfluxDBService service)
        {
var sql = "SELECT time, value FROM altitude WHERE value > 3500 ORDER BY time DESC";
            var rows = await service.Query(sql);

            var results = rows.Select(r => new AltitudeModel
            {
                Time = r.ElementAtOrDefault(0)?.ToString() ?? string.Empty,
                Altitude = r.ElementAtOrDefault(1) != null ? Convert.ToInt32(r[1]) : 0
            });

            return View(results);
        }
    }
}
