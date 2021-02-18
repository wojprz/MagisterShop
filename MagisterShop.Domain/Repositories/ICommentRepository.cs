using MagisterShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
        Task<Comment> GetAsync(Guid id);
        Task<IEnumerable<Comment>> GetAllProductComments(Guid productId);
        Task<IEnumerable<Comment>> GetAllUserComments(Guid userId);
        Task<IEnumerable<Comment>> GetAllUserComments(string login);
        Task RemoveAsync(Guid commentId);
        Task UpdateAsync(Comment comment);
    }
}
