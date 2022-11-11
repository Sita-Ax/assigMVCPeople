using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class AjaxPeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
