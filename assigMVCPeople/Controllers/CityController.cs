using assigMVCPeople.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class CityController : Controller
    {
        ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
