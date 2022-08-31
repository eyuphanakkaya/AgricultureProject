using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var Value=_addressService.GetAll();
            return View(Value);
        }
        public IActionResult DeleteAddress(int id)
        {
            var Value=_addressService.GetById(id);
            _addressService.TDelete(Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            AddressValidation validationRules=new AddressValidation();
            ValidationResult result=validationRules.Validate(address);
            if (result.IsValid)
            {
                _addressService.TInsert(address);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorCode);
                }
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var Value = _addressService.GetById(id);
            return View(Value);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {
            _addressService.TUpdate(address);
            return RedirectToAction("Index");
        }
    }
}
