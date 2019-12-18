using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoRESTServiceCRUD.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyContext")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}