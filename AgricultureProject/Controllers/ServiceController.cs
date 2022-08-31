using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var Value=_serviceService.GetAll();
            return View(Value);
        }
        public IActionResult DeleteService(int id)
        {
            var Value = _serviceService.GetById(id);
            _serviceService.TDelete(Value);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            
            var Value = _serviceService.GetById(id);
            return View(Value);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            ServiceValidation validationRules = new ServiceValidation();
            ValidationResult result = validationRules.Validate(service);
            if (result.IsValid)
            {
                _serviceService.TUpdate(service);
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
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.TInsert(service);
            return RedirectToAction("Index");
        }
    }
}
