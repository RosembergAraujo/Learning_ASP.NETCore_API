using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {  id = newBook.Id}, newBook);
        }

        [HttpDelete]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            Book bookToBeDeleted = await _bookRepository.Get(id);
            if (bookToBeDeleted == null)
                return NotFound();
                
            await _bookRepository.Delete(bookToBeDeleted.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
        {
            if(id != book.Id)
                return BadRequest();
            
            await _bookRepository.Update(book);
            return NoContent();
        }



}
}
