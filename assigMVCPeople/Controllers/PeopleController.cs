using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using assigMVCPeople.Models.ViewModels;
using assigMVCPeople.Models.Services;
using assigMVCPeople.Models.Repos;
using assigMVCPeople.Models;
using System;

namespace assigMVCPeople.Controllers
{
    public class PeopleController : Controller
    {
       IPeopleService _peopleService;
       private readonly ICityService _cityService;
        public PeopleController(IPeopleService peopleService, ICityService cityService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
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
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            return View(createPersonViewModel);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Create(createPerson);
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
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }
            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                CityId = person.Id,
            };
            return View(editPerson);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreatePersonViewModel editPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);
                return RedirectToAction(nameof(Index));
            }
            _peopleService.Create(editPerson);
            return View(editPerson);
        }

        // GET: PeopleController/Delete/5
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            if(person == null)
            {
                return RedirectToAction(nameof(Index));
            }            
            else
            {
                 _peopleService.Remove(id);

            }
            return View();           
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View(new PeopleViewModel());
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            List<Person> persons = _peopleService.Search(search);
            if(search != null)
            {
                return PartialView("_PeopleList", persons);
            }
            return BadRequest();
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
