using MagisterShop.Domain.Contexts;
using MagisterShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MagisterShopContext _entities;

        public ProductRepository(MagisterShopContext entities)
        {
            _entities = entities;
        }

        public async Task AddAsync(Product product)
        {
            await _entities.Products.AddAsync(product);
            await _entities.SaveChangesAsync();
        }

        public async Task<Product> GetAsync(Guid id) => await _entities.Products.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Product>> GetAllAsync() => await _entities.Products.ToListAsync();

        public async Task<IEnumerable<Product>> GetAllWithNameAsync(string title) => await _entities.Products.Where(x => x.Title.Contains(title)).ToListAsync();

        public async Task<IEnumerable<Product>> GetAllUserProductsAsync(Guid userId) => await _entities.Products.Where(x => x.User.Id == userId).ToListAsync();

        public async Task RemoveAsync(Guid id)
        {
            var product = await GetAsync(id);
            _entities.Products.Remove(product);
            await _entities.SaveChangesAsync();       
        }

        public async Task UpdateAsync(Product product)
        {
            _entities.Products.Update(product);
            await _entities.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(Guid id, int status)
        {
            var product = await GetAsync(id);
            product.SetStatus(status);
            await _entities.SaveChangesAsync();
        }

    }
}
