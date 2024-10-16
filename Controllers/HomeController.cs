using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeChecker.Controllers
{    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext aContext)
        {
            _context = aContext;
        }

        public IActionResult Index()
        {
            IEnumerable<ChallengeBaseInfo> displayInfo = _context.ChallengeData
                            .Select(c => new ChallengeBaseInfo(c.Id, c.ChallengeName, c.Difficulty));
            return View(displayInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
