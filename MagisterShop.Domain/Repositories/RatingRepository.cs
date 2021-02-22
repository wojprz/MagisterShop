﻿using MagisterShop.Domain.Contexts;
using MagisterShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Domain.Repositories
{
    public class RatingRepository : IRatingRepository

    {
        private readonly MagisterShopContext _entities;

        public RatingRepository(MagisterShopContext entities)
        {
            _entities = entities;
        }
        
        public Rating CreateRating()
        {
            var rating = new Rating();
            return rating;
        }

        public async Task AddAsync(Rating rating)
        {
            await _entities.AddAsync(rating);
            await _entities.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rating>> GetAllAsync() => await _entities.Ratings.ToListAsync();

        public async Task AddVoteAsync(Product product, User user, int rating)
        {
            _entities.Ratings.FirstOrDefault(x => x.ProductId == product.Id).AddVote(user.Id, rating);
            await _entities.SaveChangesAsync();
        }

        public async Task<Rating> GetRatingAsync(Guid productId)
        {
            var rating = await GetAllAsync();
            return rating.SingleOrDefault(x => x.ProductId == productId);

        }
    }
}
