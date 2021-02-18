using MagisterShop.Domain.Contexts;
using MagisterShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MagisterShopContext _entities;

        public UserRepository(MagisterShopContext entities)
        {
            _entities = entities;
        }

        public async Task AddAsync(User user)
        {
            await _entities.Users.AddAsync(user);
            await _entities.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid id) => await _entities.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string login) => await _entities.Users.SingleOrDefaultAsync(x => x.Login == login);

        public async Task<IEnumerable<User>> GetAllAsync() => await _entities.Users.ToListAsync();
    }
}
