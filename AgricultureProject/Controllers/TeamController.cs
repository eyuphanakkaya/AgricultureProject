using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var Value = _teamService.GetAll();
            return View(Value);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidation validationRules = new TeamValidation();
            ValidationResult result= validationRules.Validate(team);
            if (result.IsValid)
            {
                _teamService.TInsert(team);
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
        public IActionResult DeleteTeam(int id)
        {
            var Value = _teamService.GetById(id);
            _teamService.TDelete(Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var Value = _teamService.GetById(id);
            return View(Value);

        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {

            _teamService.TUpdate(team);
            return RedirectToAction("Index");
        }
    }
}


