using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DemoRESTServiceCRUD
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        [Required]
        public string Title { get; set; }
        [DataMember]
        [Required]
        // ReSharper disable once InconsistentNaming
        public string ISBN { get; set; }
    }

    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book item);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }
}