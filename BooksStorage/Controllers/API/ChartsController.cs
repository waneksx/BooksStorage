using BooksStorage.BookData;
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
            var book = dbContext.Books.First(x => x.Id == id);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book is missed");
            }
            book.Hits = 
            var data = book.GoogleChartData;
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
