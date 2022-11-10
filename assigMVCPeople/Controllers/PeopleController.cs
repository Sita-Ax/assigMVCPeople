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
        public ActionResult Index()
        {
            return View(_peopleService.GetAll());
        }

        // GET: PeopleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createPerson)
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
        public ActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);
            if(person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
