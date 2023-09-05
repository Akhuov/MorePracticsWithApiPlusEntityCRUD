using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookRepository
    {
        public Task CreateAsync(BookCreateDto bookCreateDto);
        public Task<string> UpdateAsync(Guid id, BookCreateDto dto);
        public Task<string> DeleteAsync(Guid id);
        public Task<IEnumerable<Book>> GetAllAsync();
        public Task<Book> GetByIdAsync(Guid id);
    }
}
