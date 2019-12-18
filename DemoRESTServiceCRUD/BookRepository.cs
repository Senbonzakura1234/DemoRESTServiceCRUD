// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DemoRESTServiceCRUD.Models;

namespace DemoRESTServiceCRUD
{

    public class BookRepository : IBookRepository
    {

        private readonly MyContext _db = new MyContext();

        //public BookRepository()
        //{
        //    AddNewBook(new Book{Title = "C# Programming", ISBN = "23422342343"});
        //    AddNewBook(new Book{Title = "Java Programming", ISBN = "123123123543"});
        //    AddNewBook(new Book{Title = "WCF Programming", ISBN = "231324243"});
        //}

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _db.Books.Find(id);
        }

        public Book AddNewBook(Book item)
        {
            _db.Books.Add(item);
            _db.SaveChanges();
            return item;
        }

        public bool DeleteABook(int id)
        {
            var idx = _db.Books.Find(id);
            if (idx == null) return false;
            _db.Books.Remove(idx);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateABook(Book item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var idx = _db.Books.Find(item.BookId);
            if (idx == null) return false;
            _db.Entry(idx).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }
    }
}


