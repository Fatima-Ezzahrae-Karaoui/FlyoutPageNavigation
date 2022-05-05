using System;

namespace FlyoutPageNavigation.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime CreatedAt { get; set; }


    }
    public enum MenuItemType
    {
        HomePage,
        AddNewBookPage,
        DetailsPage,
        AboutPage,
        ContactsPage,
        BookListPage
    }
    public class HomeMenuItem 
    {
        public MenuItemType TargetType { get; set; }
        public string IconSource { get; set; }
        public string Title { get; set; }
    }
}