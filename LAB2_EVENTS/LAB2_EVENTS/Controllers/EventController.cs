using LAB2_EVENTS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;

namespace LAB2_EVENTS.Controllers
{
    public class EventController : Controller
    {


        private static List<Event> events = new List<Event>()
        {
            new Event("event1", "kumanovo"),
            new Event("event2", "skopje"),
            new Event("event3", "veles"),
            new Event("event4", "dojshland"),
            new Event("event5", "shfajcari")
        };

        public EventController()
        {

        }


        public IActionResult GetAllEvents()
        {

            return View(events);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eventName , eventLocation")] Event e)
        {
            if (ModelState.IsValid)
            {
                events.Add(e);
                return RedirectToAction(nameof(GetAllEvents));
            }

            return View(e);
        }


        private void resetTracker()
        {
            Event.ID_TRACKER = events.Count + 1;
        }


        private Event findByID(int id)
        {
            return events.ElementAt(id - 1);
        }





        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event e = findByID(id);
            if (e == null)
            {
                return NotFound();
            }
        
            return View(e);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eventName,eventLocation")] Event e)
        {
       
            if (ModelState.IsValid)
            {
              
                    Event toEdit = findByID(id);
                    toEdit.eventLocation = e.eventLocation;
                    toEdit.eventName = e.eventName;

                return RedirectToAction(nameof(GetAllEvents));
            }
          
            return View(e);
        }


        public IActionResult Delete(int id)
        {
            events.Remove(findByID(id));
            resetTracker();
            return View("GetAllEvents" , events);
        }

          
    }
}
