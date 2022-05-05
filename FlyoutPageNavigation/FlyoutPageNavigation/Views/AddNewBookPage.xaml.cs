using FlyoutPageNavigation.Infrastructure.Repositories;
using FlyoutPageNavigation.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutPageNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewBookPage : ContentPage
    {
        private readonly IBookRepository bookRepository = new BookRepository();
        public Book Book { get; set; } = new Book();
        public AddNewBookPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Save_Button(object sender, EventArgs e)
        {
            bookRepository.Add(Book);
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Button(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /*private async void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Button_Clicked(object sender, EventArgs e)
        {
            bookRepository.Add(Book);
            await Navigation.PopModalAsync();
        }*/

    }
}