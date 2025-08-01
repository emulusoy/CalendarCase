using Calendar.Context;
using CalendarCase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarCase.Controllers
{
    public class EventController : Controller
    {
        private readonly CalendarContext _context;

        public EventController(CalendarContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(string title, string color, string description = "")
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(color))
                return BadRequest("Geçersiz veri");

            var newCategory = new Category
            {
                Name = title,
                Color = color,
                Description = string.IsNullOrWhiteSpace(description) ? "Otomatik oluşturuldu" : description
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                name = newCategory.Name,
                color = newCategory.Color
            });
        }

    }
}
