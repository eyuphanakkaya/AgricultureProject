using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _ımageService;

        public ImageController(IImageService ımageService)
        {
            _ımageService = ımageService;
        }

        public IActionResult Index()
        {
           var Value= _ımageService.GetAll();
            return View(Value);
        }
        public IActionResult DeleteImage(int id)
        {
            var Value = _ımageService.GetById(id);
            _ımageService.TDelete(Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var Value = _ımageService.GetById(id);
            return View(Value);
        }
        [HttpPost]
        public IActionResult UpdateImage(Image ımage)
        {
            _ımageService.TUpdate(ımage);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image ımage)
        {
            ImageValidation validationRules = new ImageValidation();
            ValidationResult result = validationRules.Validate(ımage);
            if (result.IsValid)
            {
                _ımageService.TInsert(ımage);
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
    }
}
