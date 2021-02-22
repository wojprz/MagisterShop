using AutoMapper;
using MagisterShop.Domain.Entities;
using MagisterShop.Domain.Repositories;
using MagisterShop.Infraastructure.DTOs;
using MagisterShop.Infraastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Infraastructure.Services
{
    public class RatingService : IRatingService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IProductRepository productRepository, IRatingRepository ratingRepository, IAutoMapperConfig config)
        {
            _productRepository = productRepository;
            _ratingRepository = ratingRepository;
            _mapper = config.Mapper;
        }

        public async Task AddVoteAsync(Product product, User user, int rating)
        {
            await _ratingRepository.AddVoteAsync(product, user, rating);
        }

        public async Task<RatingDTO> GetRatingAsync(Guid productId)
        {
            var rating = await _ratingRepository.GetRatingAsync(productId);
            return _mapper.Map<Rating, RatingDTO>(rating);
        }
    }
}
