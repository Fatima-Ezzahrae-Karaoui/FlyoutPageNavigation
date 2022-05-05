using FlyoutPageNavigation.Models;
using Couchbase.Lite;
using Couchbase.Lite.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Repositories.Infrastructure;

namespace FlyoutPageNavigation.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Database _database;
        public DatabaseManager MyDatabasemanager { get; set; }=new DatabaseManager(); 
        public BookRepository()
        {
            _database = MyDatabasemanager.GetDatabase();
        }
        public void Add(Book book)
        {
            try
            {
                if(book != null)
                {
                    string bookId = Guid.NewGuid().ToString();
                    book.CreatedAt = DateTime.Now;
                    MutableDocument mutabledocument = new MutableDocument(bookId);
                    mutabledocument.SetString("Id", book.Id);
                    mutabledocument.SetString("Title", book.Title);
                    mutabledocument.SetString("ShortDescription", book.ShortDescription);
                    mutabledocument.SetString("LongDescription", book.LongDescription);
                    mutabledocument.SetString("CreatedAt", book.CreatedAt.ToString("g"));
                    mutabledocument.SetString("Type", "book");
                    _database.Save(mutabledocument);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"exception:{e.Message}");
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var query = QueryBuilder
                               .Select(SelectResult.Expression(Expression.Property("Id")),
                                                   SelectResult.Expression(Expression.Property("Title")),
                                                   SelectResult.Expression(Expression.Property("ShortDescription")),
                                                   SelectResult.Expression(Expression.Property("LongDescription")),
                                                   SelectResult.Expression(Expression.Property("CreatedAt")))
                                                   .From(DataSource.Database(_database))
                                                   .Where(Expression.Property("type").EqualTo(Expression.Value("book"))))
            {
                IResultSet results = query.Execute();
                string json=JsonConvert.SerializeObject(results);
                return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

            }
        }
    }
}
