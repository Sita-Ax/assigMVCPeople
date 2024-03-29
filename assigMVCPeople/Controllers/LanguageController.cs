﻿using assigMVCPeople.Models;
using assigMVCPeople.Models.Services;
using assigMVCPeople.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View(_languageService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateLanguageViewModel createLanguageView = new CreateLanguageViewModel();
            return View(createLanguageView);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Create(createLanguage);
                return RedirectToAction(nameof(Index));
            }
            return View(createLanguage);
        }
        public IActionResult Details(int id)
        {
            Language language = _languageService.FindById(id);
            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Language language = _languageService.FindById(id);
            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateLanguageViewModel editLanguage = new CreateLanguageViewModel()
            {
                LanguageName = language.LanguageName,
            };
            return View(editLanguage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateLanguageViewModel editLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Edit(id, editLanguage);
                return RedirectToAction(nameof(Index));
            }
            _languageService.Create(editLanguage);
            return View(editLanguage);
        }

        public IActionResult Delete(int id)
        {
            Language language = _languageService.FindById(id);
            if (language != null)
            {
                _languageService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Search()
        {
            return View(new LanguageViewModel());
        }

        //[HttpPost]
        //public IActionResult Search(string search)
        //{
        //    List<Language> languages = _languageService.Search(search);
        //    if (search != null)
        //    {
        //        return PartialView("_LanguageList", languages);
        //    }
        //    return BadRequest();
        //}
    }
}

