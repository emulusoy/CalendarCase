using Calendar.Context;
using Microsoft.AspNetCore.Mvc;

namespace CalendarCase.ViewComponents
{
    public class EventMenuViewComponent:ViewComponent
    {
        private readonly CalendarContext _context;

        public EventMenuViewComponent(CalendarContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {          
            var values = _context.Categories.ToList();
            return View(values);
        }
    }
}
