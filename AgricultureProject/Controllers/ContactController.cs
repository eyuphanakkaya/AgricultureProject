using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgricultureProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var Value=_contactService.GetAll();
            return View(Value);
        }
        public IActionResult DeleteContact(int id)
        {
            var Value = _contactService.GetById(id);
            _contactService.TDelete(Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            ContactValidation validationRules= new ContactValidation();
            ValidationResult result=validationRules.Validate(contact);
            if (result.IsValid)
            {
                _contactService.TInsert(contact);
                contact.Date = DateTime.Now;
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value= _contactService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }

    }
}
