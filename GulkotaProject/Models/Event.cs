namespace GulkotaProject.Models
{
    /* Created by Gulkota Priyanka
     * This class creates a type for event
     * Each Event has a Event Name that is the Title, and 
     * a description for the event, the category to which the event belongs to
     * Ticket price for the event and an Image to display*/
    public class Event
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public int CategoryID { get; set; }
        public double TicketPrice { get; set; }
        public string? Description { get; set; }
        public string? ImageID { get; set; }

    }// Event
} // namespace
