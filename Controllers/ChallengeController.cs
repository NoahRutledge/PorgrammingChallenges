using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChecker.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly DatabaseContext _context;
        public ChallengeController(DatabaseContext aContext)
        {
            _context = aContext;
        }

        public IActionResult Display(int aChallengeId)
        {
            return View(_context.ChallengeData.Where(c => c.Id == aChallengeId).First());
        }
    }
}
