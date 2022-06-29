using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GulkotaProject.Models
{   
    //created by Gulkota Priyanka
    /*
     This is a supporting model for the buy view which is a form which will access this class's properties.
     This class has a overloaded constructor with 2 signatures (i.e., one is a default constructor and other 
     has 2 parameters for event name and for sale ticket price)
     The parametrized constructor is called from the cart controller's buy action method, to send the sale model as a 
     ViewModel for the sale of a specific event and the ticket price that has been selected by the user to receive further 
     information about the event user chooses to buy tickets for.
     */
    public class Sale
    {
        /* There are several properties in this class constructor thta receives the EventName and
         * TicketPrice, and also a default constructor without any method body or parameters because
         * there is a defined constructor in the class aswell. The default constructor will be required
         * for the binding model.
         * the two method are CalculateDiscount() and ProcessSale() methods
         * One SelectListItem collection for dropdown
         */
        public string? EventName { get; set; }
        public string? CustomerName {  get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string? Email { get; set; }
        public double TicketPrice { get; set; }
        public string? SaleDate { get; set; }

        [Required(ErrorMessage = "Please enter number of tickets")]
        [Range(1,int.MaxValue, ErrorMessage = "Please enter number of tickets")]
        public int Count { get; set; }
        public bool SeniorDiscount { get; set; }

        [Required(ErrorMessage ="Please select a delivery option")]
        public string? SelectedDelivery { get; set; } //for select dropdown
        public double SubTotal { get; set; }
        public double SaleDiscount { get; set; }
        public double DeliveryCharge { get; set; }
        public double AmountDue {  get; set; }

        //variable for select dropdown
        public List<SelectListItem> DeliveryOptions = new List<SelectListItem>
        {
            new SelectListItem{ Text ="Mail", Value ="Mail"},
            new SelectListItem{ Text ="Print", Value ="Print at home"},
            new SelectListItem{ Text ="Digital", Value ="Digital Ticket"},
            new SelectListItem{ Text ="Call", Value ="Will Call"}
        };

        public Sale()
        {
            /*default constructor without parameters.
            this will be required for the binding model*/
        }//default constructor

        public Sale(string? eventName, double ticketPrice)
        {
            EventName = eventName;
            TicketPrice = ticketPrice;
        }// parameterized constructor

        public void CalculateDiscount()
        {
            const double SENIOR_DISCOUNT = 0.2D;
            SaleDiscount = SENIOR_DISCOUNT * SubTotal;
        }//CalculateDiscount()

        public void ProcessSale()
        {
            //calculate the sale value and sets the sale date

            SaleDate = DateTime.Today.ToShortDateString();
            SubTotal = TicketPrice * Count;
            if(SeniorDiscount)
            {
                CalculateDiscount();
            }//seniorDiscount if

            if(SelectedDelivery == "Mail")
            {
                DeliveryCharge = 3.95;
            }
            else
            {
                DeliveryCharge = 0;
            }
            AmountDue = SubTotal - SaleDiscount + DeliveryCharge;
        }//processsale()
    }//class
}//namespace
