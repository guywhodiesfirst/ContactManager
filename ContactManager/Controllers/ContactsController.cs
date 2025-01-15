using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            ViewBag.Message = file.FileName + " uploaded successfully";
            return View();
        }
    }
}
