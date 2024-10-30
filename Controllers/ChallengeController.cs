using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChecker.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly string[] _allowedExtensions = { ".cpp", ".java", ".cs", ".py" };
        public ChallengeController(DatabaseContext aContext)
        {
            _context = aContext;
        }

        public IActionResult Display(int aChallengeId)
        {
            ViewBag.ChallengeData = _context.ChallengeData.Where(c => c.Id == aChallengeId).First();
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFile(ChallengeSubmission aSubmission)
        {
            if(aSubmission.File.Equals(null))
            {
                //Bad submission
                return Content("Bad");
            }

            string fileType = aSubmission.File.FileName.Substring(aSubmission.File.FileName.LastIndexOf("."));
            if(_allowedExtensions.Contains(fileType) == false)
            {
                return Content("Bad");
            }
         
            return Content(aSubmission.File.FileName);
            //return Content(aSubmission.Name + aSubmission.Id);
            return Redirect("/");
        }
    }
}
