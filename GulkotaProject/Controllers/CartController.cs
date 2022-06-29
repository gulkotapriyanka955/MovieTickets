using GulkotaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GulkotaProject.Controllers
{
    //created by Gulkota Priyanka
    public class CartController : Controller
    {
        public IActionResult Buy(int id)
        {
            /* get the ID of the event that the user wants to buy ticket for
             * then using the EventsService gets an object representing the event.*/

            EventsService eventsService = new EventsService();
            Event selectedEvent = eventsService.GetEvent(id);

            /*start sale by creating Sale Object and setting the name of the event
             * and ticket price*/

            Sale newSale = new Sale(selectedEvent.Title, selectedEvent.TicketPrice);

            return View(newSale);
        }//Buy

        public IActionResult Confirmation(Sale model)
        {
            //the binding model contains the form data for buying ticket.

            if (ModelState.IsValid)
            {
                //call the saleObject's method to calculate the sale price
                model.ProcessSale();

                /*pass the sale object to the Confirmation view as the 
                 *viewModel to display the sale confirmation*/

                return View(model);
                 
            }//modelValid
            else
            {
                return View("Buy", model);
            }//else
        }//confirmation
    }//CartController
}//namespace
