using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services
{//CRUD
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext dbContext;
        public BookRepository(AppDbContext DbContext)
        {
            this.dbContext = DbContext;
        }

        public async Task CreateAsync(BookCreateDto bookCreateDto)
        {
            var newBook = new Book()
            {
                Id = Guid.NewGuid(),
                Name = bookCreateDto.Name,
            };
            await dbContext.Books.AddAsync(newBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> UpdateAsync(Guid id,BookCreateDto dto)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return "Book not Found";
            }
            else
            {
                book.Name = dto.Name;
                dbContext.Update(book);
                await dbContext.SaveChangesAsync();
                return "Book Updated";
            }
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return "Book not Found";
            }
            else
            {
                dbContext.Remove(book);
                await dbContext.SaveChangesAsync();
                return "Book Deleted";
            }
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            var result = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var result = await dbContext.Books.ToListAsync();
            return result;
        }


    }
}
