using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeChecker.Controllers
{    public class HomeController : Controller
    {
        private readonly CodecheckerContext _context;
        public HomeController(CodecheckerContext aContext)
        {
            _context = aContext;
        }

        public IActionResult Index()
        {
            return View(_context.ChallengeData.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
