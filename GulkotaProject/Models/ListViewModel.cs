namespace GulkotaProject.Models
{
    //Created by Gulkota Priyanka
    public class ListViewModel
    {
        public IEnumerable<Event> Events { get; }
        public List<Category> Categories { get; set; }
        public string? SelectedCategory { get; }

        public ListViewModel(IEnumerable<Event> events, List<Category> categories, string selectedCategory)
        {
            //set the properties
            Events = events;
            Categories = categories;
            SelectedCategory = selectedCategory;
        }//ListViewModel constructor
    }//ListViewModel
}//namespace
