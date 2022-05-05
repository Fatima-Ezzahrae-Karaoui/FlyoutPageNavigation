using FlyoutPageNavigation.Infrastructure.Repositories;
using FlyoutPageNavigation.Models;
using FlyoutPageNavigation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutPageNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListPage : ContentPage
    {
        private readonly IBookRepository bookRepository = new BookRepository();
        public BookListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Appeller la méthode get 
            BooksListView.ItemsSource = bookRepository.GetBooks();
        }

        private async void BooksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Book;
            if (item == null)
            {
                return;
            }
            await Navigation.PushAsync(new BookDetailsPage(item));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddNewBookPage()));
        }
    }
}