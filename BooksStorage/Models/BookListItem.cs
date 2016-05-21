using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStorage.Models
{
    public class BookListItem
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}