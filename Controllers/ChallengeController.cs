using CodeChecker.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChecker.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string[] _allowedExtensions = { ".cpp", ".java", ".cs", ".py" };
        public ChallengeController(DatabaseContext aContext, IWebHostEnvironment aWebHostEnvironment)
        {
            _context = aContext;
            _hostingEnvironment = aWebHostEnvironment;
        }

        [HttpGet]
        public IActionResult ChallengeSubmission(int aChallengeId)
        {
            ViewBag.ChallengeData = _context.ChallengeData.Where(c => c.Id == aChallengeId).First();
            ViewBag.ErrorString = TempData["ErrorString"]?.ToString();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChallengeSubmission(ChallengeSubmission aSubmission)
        {
            if(aSubmission.File.Equals(null))
                return ReturnError("No file submitted", aSubmission.Id);

            int index = aSubmission.File.FileName.LastIndexOf(".");
            if(index < 0)
                return ReturnError("Incorrect file type uploaded", aSubmission.Id);

            string fileType = aSubmission.File.FileName.Substring(index);
            if(index < 0 || _allowedExtensions.Contains(fileType) == false)
                return ReturnError("Incorrect file type uploaded", aSubmission.Id);


            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "UploadedSubmissions");
            if (System.IO.Directory.Exists(path) == false)
                System.IO.Directory.CreateDirectory(path);

            string newFileName = aSubmission.Id + "-" + DateTime.Now.ToString("yyyy-dd-m--HH-mm-ss") + fileType;
            string filePath = Path.Combine(path, newFileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await aSubmission.File.CopyToAsync(fileStream);
            }

            return Redirect("/");
        }

        private RedirectToActionResult ReturnError(string anErrorString, int anId)
        {
            TempData["ErrorString"] = anErrorString;
            return RedirectToAction("ChallengeSubmission", new { aChallengeId = anId });
        }
    }
}
