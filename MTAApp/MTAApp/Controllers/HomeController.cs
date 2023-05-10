using Microsoft.AspNetCore.Mvc;
using MTAApp.Logic;
using MTAApp.Models;
using System.Diagnostics;

namespace MTAApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PollService pollService;

        public HomeController(ILogger<HomeController> logger, PollService pollService)
        {
            _logger = logger;
            this.pollService = pollService;

        }

        public IActionResult Index()
        {
            var polls = pollService.GetPolls();
            return View(polls);
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