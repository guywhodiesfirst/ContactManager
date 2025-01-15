using Microsoft.AspNetCore.Mvc;
using ContactManager.Helpers;
using ContactManager.Exceptions;
using ContactManager.Data;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactManagerDataContext _context;
        public ContactsController(ContactManagerDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                var records = CsvUploadHandler.ParseCsv(file);
                foreach (var record in records)
                {
                    var contact = MappingHelper.MapToContact(record);
                    _context.Contacts.Add(contact);
                }
                _context.SaveChanges();
                ViewBag.Message = "Data from " + file.FileName + " uploaded successfully";
            }
            catch (CsvException ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
            return View();
        }
    }
}
