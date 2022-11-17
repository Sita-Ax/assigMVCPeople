﻿using Microsoft.AspNetCore.Http;
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
                    ModelState.AddModelError("Name, PhoneNumber & City", ex.Message);
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
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City,
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
            if(person != null)
            {
                _peopleService.Remove(id);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, CreatePersonViewModel deletePerson)
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
