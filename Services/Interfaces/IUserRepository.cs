using Domain.Entities;
using Services.Dtos;

namespace Services.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateAsync(UserCreateDto userCreateDto, PasswordCreateDto newPassword);
        public Task<string> UpdateAsync(Guid id, UserUpdateDto dto);
        public Task<string> DeleteAsync(Guid id);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> GetByIdAsync(Guid id);
    }
}
