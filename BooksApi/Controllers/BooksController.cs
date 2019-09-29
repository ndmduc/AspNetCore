using System.Collections.Generic;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookServices;

        public BooksController(BookService bookService)
        {
            _bookServices = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get() => _bookServices.Get();

        [HttpGet("{id:length(24)}", Name="GetBook")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookServices.Get(id);

            if(book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody]Book book)
        {
            _bookServices.Create(book);

            return CreatedAtAction("GetBook", new { id = book.Id.ToString()}, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookServices.Get(id);
            if(book == null)
            {
                return NotFound();
            }

            _bookServices.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:string}")]
        public IActionResult Delete(string id)
        {
            var book = _bookServices.Get(id);
            if(book == null)
            {
                return NotFound();
            }

            _bookServices.Remove(id);

            return NoContent();
        }
    }
}