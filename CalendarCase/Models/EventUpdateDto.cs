namespace CalendarCase.Models
{
    public class EventUpdateDto
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? AllDay { get; set; }
    }
}
