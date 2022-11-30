using assigMVCPeople.Models;
using assigMVCPeople.Models.Services;
using assigMVCPeople.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cityService;
        private ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel createCityView = new CreateCityViewModel();
            createCityView.Countries = _countryService.GetAll();
            return View(createCityView);
        }

        [HttpPost]
        public IActionResult Create(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Create(createCity);
                return RedirectToAction(nameof(Index));
            }
            return View(createCity);
        }

        public IActionResult Details(int id)
        {
            City city = _cityService.FindById(id);
            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        public IActionResult Edit(int id)
        {
            City city = _cityService.FindById(id);
            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateCityViewModel editCity = new CreateCityViewModel()
            {
                CityName = city.CityName,
                ZipCode = city.ZipCode,
            };
            return View(editCity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateCityViewModel editCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Edit(id, editCity);
                return RedirectToAction(nameof(Index));
            }
            _cityService.Create(editCity);
            return View(editCity);
        }

        public IActionResult Delete(int id)
        {
            City city = _cityService.FindById(id);
            if (city== null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _cityService.Remove(id);
            }
            return View();
        }

        public IActionResult Search()
        {
            return View(new CityViewModels());
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            List<City> city = _cityService.Search(search);
            if (search != null)
            {
                return PartialView("_CityList", city);
            }
            return BadRequest();
        }
    }
}
