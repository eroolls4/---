using System.ComponentModel.DataAnnotations;

namespace LAB2_EVENTS.Models
{
    public abstract class BaseEvent
    {
        public static int ID_TRACKER = 1;

        public int Id { get; set; }


        public BaseEvent()
        {
            this.Id = ID_TRACKER++;
        }
    }
}
