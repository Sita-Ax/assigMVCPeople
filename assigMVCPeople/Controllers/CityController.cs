using assigMVCPeople.Models;
using assigMVCPeople.Models.Services;
using assigMVCPeople.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class CityController : Controller
    {
        ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_cityService.GetAll());
        }
        public IActionResult Create()
        {
            CreateCityViewModels createCityView = new CreateCityViewModels();
            createCityView.Countries = _countryService.GetAll();
            return View(createCityView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCityViewModels createCity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cityService.Create(createCity);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("CityName, Zipcode", ex.Message);
                    return View(createCity);
                }
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

            CreateCityViewModels editCity = new CreateCityViewModels()
            {
                CityName = city.CityName,
                ZipCode = city.ZipCode,
            };
            return View(editCity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateCityViewModels editCity)
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
            if (city == null)
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
