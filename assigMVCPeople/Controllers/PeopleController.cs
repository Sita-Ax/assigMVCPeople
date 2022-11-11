using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using assigMVCPeople.Models.ViewModels;
using assigMVCPeople.Models.Services;
using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models;

namespace assigMVCPeople.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;

        public PeopleController()
        {
            _peopleService = new PeopleService(new InMemoryPeopleRepo());
        }
        // GET: PeopleController
        public IActionResult Index()
        {
            return View(_peopleService.GetAll());
        }

        // GET: PeopleController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Create(createPerson);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("Person", ex.Message);
                    return View(createPerson);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(createPerson);
        }

        // GET: PeopleController/Details/5
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);
            if(person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: PeopleController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Delete/5
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            if(person == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult People(string search)
        {
            if(search != null)
            {
                return View(_peopleService.Search(search));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PartialViewPeople()
        {
            return PartialView("_PeopleList", _peopleService.GetAll());
        }

        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Person person = _peopleService.FindById(id);
            if(person != null)
            {
                return PartialView("_PersonDetails", person);
            }
            return NotFound();
        }
        public IActionResult AjaxDelete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (_peopleService.Remove(id))
            {
                return PartialView("_PeopleList", _peopleService.GetAll());
            }
            return NotFound();
        }
    }
}
