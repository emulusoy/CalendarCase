﻿namespace CalendarCase.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAllDay { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
