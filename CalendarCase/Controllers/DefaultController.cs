using Calendar.Context;
using CalendarCase.Entities;
using CalendarCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarCase.Controllers
{
    public class DefaultController : Controller
    {
        private readonly CalendarContext _context;

        public DefaultController(CalendarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events
                .Select(e => new
                {
                    id = e.Id,
                    title = e.Title,
                    start = e.Start.HasValue ? e.Start.Value.ToString("o") : null,
                    end = e.End.HasValue ? e.End.Value.ToString("o") : null,
                    allDay = e.AllDay, // `AllDay` bilgisini de gönderin
                    color = e.Color,
                    description = e.Description,
                    categoryId = e.CategoryId
                })
                .ToListAsync();

            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { status = false, message = "Model validation failed", errors });
            }

            try
            {
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();
                return Ok(new { status = true, message = "Etkinlik kaydedildi.", id = newEvent.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent([FromBody] EventUpdateDto updatedEventDto)
        {
            if (!ModelState.IsValid)
            {
                // ModelState hatalarını loglayarak sorunun kaynağını daha iyi görebilirsiniz.
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                // Console.WriteLine(string.Join(", ", errors)); 

                return BadRequest(new { status = false, message = "Geçersiz veri formatı." });
            }

            try
            {
                var existingEvent = await _context.Events.FindAsync(updatedEventDto.Id);

                if (existingEvent == null)
                {
                    return NotFound(new { status = false, message = "Etkinlik bulunamadı." });
                }

                existingEvent.Start = updatedEventDto.Start;
                existingEvent.End = updatedEventDto.End;
                existingEvent.AllDay = updatedEventDto.AllDay ?? false; // Null ise false yapın

                await _context.SaveChangesAsync();

                return Ok(new { status = true, message = "Etkinlik başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEvent([FromBody] int id)
        {
            try
            {
                var existingEvent = await _context.Events.FindAsync(id);

                if (existingEvent == null)
                {
                    return NotFound(new { status = false, message = "Etkinlik bulunamadı." });
                }

                _context.Events.Remove(existingEvent);
                await _context.SaveChangesAsync();

                return Ok(new { status = true, message = "Etkinlik başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = false, message = ex.Message });
            }
        }
    }
}