using System.ComponentModel.DataAnnotations;

namespace LAB2_EVENTS.Models
{
    public class Event
    {
        public static int ID_TRACKER = 1;

        public int Id { get; set; }

        [Required]
        public string eventName { get; set; }


        [Required]
        [MaxLength(30), MinLength(5)]
        public string eventLocation { get; set; }

        public Event(string eventName, string eventLocation)
        {
            this.eventName = eventName;
            this.eventLocation = eventLocation;
            this.Id = ID_TRACKER++;
        }

        public Event()
        {
            this.Id = ID_TRACKER++;
        }
    }
}
