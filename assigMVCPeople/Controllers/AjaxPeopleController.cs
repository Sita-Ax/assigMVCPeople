using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assigMVCPeople.Controllers
{
    public class AjaxPeopleController : Controller
    {
        // GET: AjaxPeopleController
        public ActionResult Index()
        {
            return View();
        }

    }   

}
