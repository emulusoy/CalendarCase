using Microsoft.AspNetCore.Mvc;

namespace CalendarCase.Controllers
{
    public class EventController : Controller
    {
        public IActionResult _EventMenu()
        {
            return View();
        }
    }
}
