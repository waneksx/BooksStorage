using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStorage.Models
{
    public class BookHits
    {
        public Book book { get; set; }
        public IList<Hit> Hits { get; set; }
    }
}