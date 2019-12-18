// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DemoRESTServiceCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookServices.svc or BookServices.svc.cs at the Solution Explorer and start debugging.
    public class BookServices : IBookServices
    {
        private static readonly IBookRepository Repository = new BookRepository();
        public List<Book> GetBooksList()
        {
            var rs = Repository.GetAllBooks();
            return rs;
            
        }

        public Book GetBookById(string id)
        {
            return Repository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book)
        {
            Repository.AddNewBook(book);
            return "success";
        }

        public string UpdateBook(Book book, string id)
        {
            var updated = Repository.UpdateABook(book);
            return updated ? "Book with id = " + id + " updated successfully." : "Unable to update book with id = " + id;
        }

        public string DeleteBook(string id)
        {
            var deleted = Repository.DeleteABook(int.Parse(id));
            return deleted ? "Book with id = " + id + " deleted successfully." : "Unable to delete book with id = " + id;
        }
    }
}
