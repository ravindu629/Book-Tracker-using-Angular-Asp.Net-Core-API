using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Models;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailController : ControllerBase
    {
        private readonly BookDetailContext _context;

        public BookDetailController(BookDetailContext context)
        {
            _context = context;
        }

        // GET: api/BookDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetail>>> GetBookDetails()
        {
            return await _context.BookDetails.ToListAsync();
        }

        // GET: api/BookDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetail>> GetBookDetail(int id)
        {
            var bookDetail = await _context.BookDetails.FindAsync(id);

            if (bookDetail == null)
            {
                return NotFound();
            }

            return bookDetail;
        }

        // PUT: api/BookDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetail(int id, BookDetail bookDetail)
        {
            if (id != bookDetail.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.BookDetails.ToListAsync());
        }

        // POST: api/BookDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDetail>> PostBookDetail(BookDetail bookDetail)
        {
            _context.BookDetails.Add(bookDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.BookDetails.ToListAsync());
        }

        // DELETE: api/BookDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDetail(int id)
        {
            var bookDetail = await _context.BookDetails.FindAsync(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            _context.BookDetails.Remove(bookDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.BookDetails.ToListAsync());
        }

        private bool BookDetailExists(int id)
        {
            return _context.BookDetails.Any(e => e.BookId == id);
        }
    }
}
