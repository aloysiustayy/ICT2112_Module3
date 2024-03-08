using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DomainLayer.Entity;
using DomainLayer.Interface;
using DomainLayer.Control;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdministratorTDG _administratorDbContext;

        public HomeController(ILogger<HomeController> logger, IAdministratorTDG administratorDbContext)
        {
            _logger = logger;
            _administratorDbContext = administratorDbContext;
        }

        public IActionResult Index()
        {
            AdministratorControl ac = new AdministratorControl(_administratorDbContext);
            return View(ac.RetrieveAllAdministrativeAccount());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
