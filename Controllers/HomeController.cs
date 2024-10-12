using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeChecker.Controllers
{    public class HomeController : Controller
    {
        private ChallengeList _challengeList = new ChallengeList();


        public IActionResult Index()
        {
            return View(_challengeList.GetRefreshedChallengeBasicInfoList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
