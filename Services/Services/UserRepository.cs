using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext dbContext;
        public UserRepository(AppDbContext DbContext)
        {
            this.dbContext = DbContext;
        }
        public async Task CreateAsync(UserCreateDto userCreateDto, PasswordCreateDto newPassword)
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                LastName = userCreateDto.LastName,
                FirstName = userCreateDto.FirstName,
                Email = userCreateDto.Email,
            };
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == newUser.Id);

            Password newpassword = new Password()
            {
                Id = Guid.NewGuid(),
                PasswordString = newPassword.PasswordString,
                UserId = user.Id,
            };
            await dbContext.Passwords.AddAsync(newpassword);
            await dbContext.SaveChangesAsync(); 

            
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return "User Deleted";
            }
            else { return "User not found"; }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<string> UpdateAsync(Guid id, UserUpdateDto dto)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Email = dto.Email;
                await dbContext.SaveChangesAsync();
                return "User Updated";
            }
            else return "User Not Found";
        }
    }
}
