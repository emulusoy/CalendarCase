using Microsoft.AspNetCore.Mvc;

namespace CalendarCase.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
