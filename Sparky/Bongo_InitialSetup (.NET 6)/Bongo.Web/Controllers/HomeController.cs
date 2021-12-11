using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bongo.Web.Controllers
{
    /// <summary>
    /// Home controller class
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger Object
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger dependency that will be injected.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            // Set the dependency injection.
            _logger = logger;
        }

        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Return default view
            return View();
        }

        /// <summary>
        /// Privacy Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            // Return default view
            return View();
        }

    }
}
