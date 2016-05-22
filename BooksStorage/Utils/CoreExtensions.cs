using BooksStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStorage.Utils
{
    public static class CoreExtensions
    {

        
        public static void Add(this BookData.BookDbContext books, string title, string authorFirstName, string authorLastName)
        {
            Author author = new Author { FirstName = authorFirstName, LastName = authorLastName };
            bool authentic = true;            
            foreach (var item in books.Authors)
            {
                if (author.FirstName == item.FirstName && author.LastName == item.LastName)
                {
                    author = item;
                    authentic = false;
                }
            }
            if (authentic)
            {
                books.Authors.Add(author);
            }            
            books.Books.Add(new Book { Title = title, Author = author });
            books.SaveChanges();
        }

      
    }
}