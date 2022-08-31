using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            _newsService.GetAll();
            return View();
        }
        public IActionResult DeleteNews(int id)
        {
            var Value=_newsService.GetById(id);
            _newsService.TDelete(Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateNews(int id)
        {
            var Value = _newsService.GetById(id);
            return View(Value);
        }
        [HttpPost]
        public IActionResult UpdateNews(News news)
        {
            _newsService.TUpdate(news);
            return RedirectToAction("Index");
             
        }
        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNews(News news)
        {
            _newsService.TInsert(news);
            return RedirectToAction("Index");
        }
    }

}
