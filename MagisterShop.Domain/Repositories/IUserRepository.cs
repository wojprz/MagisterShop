using MagisterShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string login);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetAllAsync(int page, int count = 10);
        Task<bool> IsEmailUnique(string email);
        Task<bool> IsLoginUnique(string login);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(string login);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task UpdateStatusAsync(Guid id, int status);
    }
}
