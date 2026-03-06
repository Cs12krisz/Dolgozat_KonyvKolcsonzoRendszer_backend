using KonyvkolcsonzoRendszer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonyvkolcsonzoRendszer.Models;
using KonyvkolcsonzoRendszer.Services.Dtok;

namespace KonyvkolcsonzoRendszer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _book;

        public BooksController(IBookService book)
        {
            _book = book;
        }
        [HttpPost]
        public async Task<ActionResult> NewBook(NewBookDto newBook)
        {
            var response = await _book.PostNewBook(newBook);
            if (response is string)
            {
                return BadRequest(response);
            }
            return StatusCode(201, response);

        }

        [HttpPut("{id}/borrow")]
        public async Task<ActionResult> BorrowBook(int id)
        {
            var resp = await _book.PutBorrowBook(id);


            return Ok(resp);
        }

        [HttpGet("borrowed")]
        public async Task<ActionResult> GetBorrowedBooks()
        {
            var resp = await _book.GetBorrowedBook();
            return Ok(resp);
        }
    }
}
