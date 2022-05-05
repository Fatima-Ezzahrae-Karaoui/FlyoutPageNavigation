using FlyoutPageNavigation.Models;
using System.Collections.Generic;

namespace FlyoutPageNavigation.Infrastructure.Repositories
{
    public interface IBookRepository
    {
         void Add(Book book);
         IEnumerable<Book> GetBooks();
    }
}
