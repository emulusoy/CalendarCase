using CalendarCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Context
{
    public class CalendarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MULUSOY\\SQLEXPRESS01;initial Catalog=CalendarCase;integrated security=true;TrustServerCertificate=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
