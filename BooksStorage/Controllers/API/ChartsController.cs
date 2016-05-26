using BooksStorage.BookData;
using BooksStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksStorage.Controllers.API
{
    public class ChartsController : ApiController
    {
       BookDbContext dbContext = new BookDbContext();
        [HttpGet]
        public HttpResponseMessage Hits(int id)
        {
            BookHits b = dbContext.Books.Select(x => new BookHits { book = x, Hits = x.Hits }).First(x => x.book.Id == id);
            bool todayHit = false;
            foreach (var item in b.Hits)
            {
                if (item.Date == DateTime.UtcNow.Date)
                    todayHit = true;
            }
            if (b.Hits.Count == 0  || !todayHit)
                dbContext.Books.First(x => x.Id == id).Hits.Add(new Hit { Date = DateTime.UtcNow.Date, Count = 1 });
            else dbContext.Books.First(x => x.Id == id).Hits.FirstOrDefault(x => x.Date == DateTime.UtcNow.Date).Count++;
            if (b == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book is missed");
            }
            
            var data = b.book.GoogleChartData;
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
