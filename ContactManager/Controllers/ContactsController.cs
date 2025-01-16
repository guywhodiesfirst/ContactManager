﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult List()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact is null)
            {
                return View("Error");
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = _context.Contacts
                .FirstOrDefault(c => c.Id == id);
            if (contact is not null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return RedirectToAction("List", "Contacts");
        }
    }
}
