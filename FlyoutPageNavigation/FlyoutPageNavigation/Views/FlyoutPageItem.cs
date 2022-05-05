using System;

namespace FlyoutPageNavigation
{
    public enum MenuItemType
    {
        HomePage,
        AddNewBookPage,
        DetailsPage,
        AboutPage,
        ContactsPage,
        BookListPage
    }
    public class FlyoutPageItem
	{
		public string Title { get; set; }
		public string IconSource { get; set; }
		public Type TargetType { get; set; }
	}
}