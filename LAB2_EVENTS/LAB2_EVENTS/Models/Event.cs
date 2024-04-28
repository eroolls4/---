using System.ComponentModel.DataAnnotations;

namespace LAB2_EVENTS.Models
{


    public class Event : BaseEvent
    {
        [Required]
        public string eventName { get; set; }


        [Required]
        [MaxLength(30), MinLength(5)]
        public string eventLocation { get; set; }


        public Event(string eventName, string eventLocation)
        {
            this.eventName = eventName;
            this.eventLocation = eventLocation;
        }


        public Event() { }





    }
}
