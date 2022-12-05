using assigMVCPeople.Models;
using assigMVCPeople.Models.Services;
using assigMVCPeople.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View(_countryService.GetAll());
        }

        public IActionResult Create()
        {
            return View(new CreateCountryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _countryService.Create(createCountry);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("CountryName, InternationalCallingCode", ex.Message);
                    return View(createCountry);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(createCountry);
        }

        public IActionResult Details(int id)
        {
            Country country = _countryService.FindById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        public IActionResult Edit(int id)
        {
            Country country = _countryService.FindById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateCountryViewModel editCountry = new CreateCountryViewModel()
            {
                CountryName = country.CountryName,
                InternationalCallingCode = country.InternationalCallingCode,
            };
            return View(editCountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateCountryViewModel editCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Edit(id, editCountry);
                return RedirectToAction(nameof(Index));
            }
            _countryService.Create(editCountry);
            return View(editCountry);
        }

        public IActionResult Delete(int id)
        {
            Country country = _countryService.FindById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _countryService.Remove(id);

            }
            return View();
        }

        public IActionResult Search()
        {
            return View(new CountriesViewModel());
        }

        //[HttpPost]
        //public IActionResult Search(string search)
        //{
        //    List<Country> countries = _countryService.Search(search);
        //    if (search != null)
        //    {
        //        return PartialView("_CountryList", countries);
        //    }
        //    return BadRequest();
        //}
    }
}
