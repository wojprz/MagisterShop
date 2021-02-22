using MagisterShop.Domain.Entities;
using MagisterShop.Infraastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Infraastructure.Services
{
    public interface IRatingService
    {
        Task AddVoteAsync(Product product, User user, int rating);
        Task<RatingDTO> GetRatingAsync(Guid productId);
    }
}
