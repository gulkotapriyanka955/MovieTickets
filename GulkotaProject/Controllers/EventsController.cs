using GulkotaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GulkotaProject.Controllers
{
    //Created by Gulkota Priyanka
    /*This control returns the list of events and event details.
     * It uses the events service to send data and get the event details
     * for displaying the views */

    public class EventsController : Controller
    {
        public IActionResult EventList(string id ="All")
        {
            /*uses event service to get events,either all if no incoming value,
             * or based on the id if the event*/
            //Instantiate the EventsService class

            EventsService eventsService = new EventsService();

            //List of categories
            List<Category> categories = eventsService.GetCategories();
            //gets all categories

            //List of events
            List<Event> events = new List<Event>(); //instantiating events list.

            //get the events based on category id
            if (id == "All")
            {
                //gets all events from the events service.
                events = eventsService.GetAllEvents();
            }
            else
            {
                /*ID user asks for the category of events. so, based on the Id
                 * find the category being asked for, then use the category to return
                 * all events of that type*/

                //variable to hold the category id.
                int selectedCategoryId = 0;
                //loop through the categories to find the category id.
                foreach(Category cat in categories)
                {
                    if (cat.Name == id)
                    {
                        selectedCategoryId = cat.ID;
                    }
                }//for each to find the category
                foreach(Event anEvent in eventsService.GetAllEvents())
                {
                    if(anEvent.CategoryID == selectedCategoryId)
                    {
                        events.Add(anEvent);
                    }//foreach for finding elements
                }
            }//EventList()
             //this action method uses a view model: ListViewModel in order to return the
             //collection of events

            ListViewModel viewModel = new ListViewModel(events, categories, id);
            //the constructor for the ListViewModel takes 3 arguments

            return View(viewModel);
        }//EventList()
        public IActionResult Details(int id)
        {
            EventsService eventsService = new EventsService();
            Event oneEvent = eventsService.GetEvent(id);
            return View(oneEvent);
        }//Details()
    }//EventsController
}//namespace
