using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChecker.Controllers
{
    public class ChallengeController : Controller
    {
        public IActionResult Display(int aChallengeId)
        {
            return View(aChallengeId);
        }
    }
}
