using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace H_M_4_Sep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookRepository bookRepository { get; set; }

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] BookCreateDto BookDto)
        {
            await bookRepository.CreateAsync(BookDto);
            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var books = await bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetUserById(Guid bookId)
        {
            var book = await bookRepository.GetByIdAsync(bookId);
            return Ok(book);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromForm] Guid bookId)
        {
            var res = await bookRepository.DeleteAsync(bookId);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] Guid bookId, [FromForm] BookCreateDto book)
        {
            var res = await bookRepository.UpdateAsync(bookId, book);
            return Ok(res);
        }
    }
}
