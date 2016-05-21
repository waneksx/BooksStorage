using BooksStorage.Models;
using BooksStorage.BookData;
using BooksStorage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStorage.Controllers
{
    public class BooksController : Controller
    {
        BookDbContext dbContext = new BookDbContext();


        

        // GET: Books
        public ActionResult Index()
        {
            
            var list = dbContext.Books
                .Select(x => new BookListItem
                {
                    Id = x.Id,
                    Book = x,
                    Author = x.Author,
                    
                }).ToList();
           

            return View(list);
            
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(BookListItem bli)
        {
            try
            {
                dbContext.Add(bli.Book.Title, bli.Author.FirstName, bli.Author.LastName);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var bookListItem = dbContext.Books
               .Select(x => new BookListItem
               {
                   Id = x.Id,
                   Book = x,
                   Author = x.Author,

               }).First(x=>x.Id == id);
            return View(bookListItem);
            
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookListItem bli)
        {
            try
            {
                BookListItem b = dbContext.Books.Select(x => new BookListItem
                {
                    Id = x.Id,
                    Book = x,
                    Author = x.Author,

                }).First(x => x.Id == id);
                b.Book.Title = bli.Book.Title;
                b.Author.FirstName = bli.Author.FirstName;
                b.Author.LastName = bli.Author.LastName;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dbContext.Books.Remove(dbContext.Books.First(x => x.Id == id));
                dbContext.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
