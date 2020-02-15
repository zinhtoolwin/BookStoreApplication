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
using Newtonsoft.Json;
using BookRentApplication.Models.ViewModel;

namespace BookRentApplication.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public JsonResult GetAuthors()
        {
           
            var author = from a in _context.Authors
                         select new
                         {
                             a.Author_Id,
                             a.Author_Name,
                             books = (from b in _context.Books
                                      where b.AuthorId == a.Author_Id
                                      select new { b.Book_Id, b.Book_Name}).ToList()
                         };
            return new JsonResult(author);
        }
        
        // GET: api/Authors/5
        [HttpGet("{id}")]
        public JsonResult GetAuthor(int id)
        {
                       
            var author = from a in _context.Authors 
                         where Convert.ToInt32(a.Author_Id) == id
                         select new
                         {
                             a.Author_Id,
                             a.Author_Name,
                             books = (from b in _context.Books
                                      where  b.AuthorId == a.Author_Id
                                      select new { b.Book_Id, b.Book_Name }).ToArray()
                         };
            
            return new JsonResult(author);
        }

        // PUT: api/Authors/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Author_Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Author_Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return author;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Author_Id == id);
        }
    }
}
