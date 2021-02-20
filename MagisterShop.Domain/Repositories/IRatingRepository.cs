using MagisterShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Domain.Repositories
{
    public interface IRatingRepository
    {
        Task AddAsync(Guid productId);
        Task<IEnumerable<Rating>> GetAllAsync();
        Task AddVoteAsync(Product product, User user, int rating);
        Task<Rating> GetRatingAsync(Guid productId);
    }
}
