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
    public class CommentRepository : ICommentRepository
    {
        private readonly MagisterShopContext _entities;

        public CommentRepository(MagisterShopContext entities)
        {
            _entities = entities;
        }

        public async Task AddAsync(Comment comment)
        {
            await _entities.AddAsync(comment);
            await _entities.SaveChangesAsync();
        }

        public async Task<Comment> GetAsync(Guid id) => await _entities.Comments.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Comment>> GetAllProductComments(Guid productId, int page, int count) => await _entities.Comments.Where(x => x.ProductId == productId).Skip((page - 1) * count).Take(count).ToListAsync();

        public async Task<IEnumerable<Comment>> GetAllUserComments(Guid userId, int page, int count) => await _entities.Comments.Where(x => x.User.Id == userId).Skip((page - 1) * count).Take(count).ToListAsync();

        public async Task<IEnumerable<Comment>> GetAllUserComments(string login, int page, int count) => await _entities.Comments.Where(x => x.User.Login == login).Skip((page - 1) * count).Take(count).ToListAsync();

        public async Task RemoveAsync(Guid commentId)
        {
            var comment = await GetAsync(commentId);
            _entities.Remove(comment);
            await _entities.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _entities.Comments.Update(comment);
            await _entities.SaveChangesAsync();
        }
    }
}
