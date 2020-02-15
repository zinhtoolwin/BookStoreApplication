using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookRentApplication.Data;
using BookRentApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookRentApplication.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public JsonResult GetBooks()
        {
            var books = _context.Books.Include(a => a.Author).Select(b=>new BookViewModel() {Book_Id=b.Book_Id,Book_Name=b.Book_Name,Author_Name=b.Author.Author_Name }).ToList();
            return new JsonResult(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public JsonResult GetBook(int id)
        {
            var book = _context.Books.Where(b => b.Book_Id == id).Include(b => b.Author).Select(b=>new BookViewModel() { Book_Id =b.Book_Id,Book_Name=b.Book_Name,Author_Name=b.Author.Author_Name}).SingleOrDefault();

            return new JsonResult(book);
            

            
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Book_Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Book_Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Book_Id == id);
        }
    }
}
