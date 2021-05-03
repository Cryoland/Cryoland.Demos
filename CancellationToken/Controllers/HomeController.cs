using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace CancellationToken.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(System.Threading.CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting to do slow work");
            
            // Imagine long-running query to database:
            await Task.Delay(10_000, cancellationToken);

            _logger.LogInformation("Finished slow delay of 10 seconds.");

            return Content(string.Empty);
        }
    }
}
