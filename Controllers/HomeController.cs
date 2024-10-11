using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeChecker.Controllers
{    public class HomeController : Controller
    {
        private ChallengeList _challengeList = new ChallengeList();

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            // Ideally pull from a database an IEnumerable of challenges to show in a table and pass to View();
            return View(_challengeList.GetRefreshedChallengeList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
