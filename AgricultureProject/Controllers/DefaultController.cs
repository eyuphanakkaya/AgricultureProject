using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
