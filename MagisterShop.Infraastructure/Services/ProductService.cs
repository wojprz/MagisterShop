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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IRatingRepository ratingRepository, IUserRepository userRepository,  IAutoMapperConfig config)
        {
            _productRepository = productRepository;
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _mapper = config.Mapper;
        }

        public async Task CreateAsync(Product product, Guid userId)
        {
            if (product.Title == null)
            {
                throw new Exception();
            }
            if (product.Description == null)
            {
                throw new Exception();
            }

            var rating = _ratingRepository.CreateRating();
            var user = _userRepository.GetAsync(userId);

            if (user == null)
            {
                throw new Exception();
            }


            var newProduct = new Product(user, product.Title, product.Description, rating);

            await _productRepository.AddAsync(newProduct);
        }

        public async Task<ProductDTO> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync(int page, int count = 10)
        {
            var product = await _productRepository.GetAllAsync(page, count);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllWithNameAsync(string title)
        {
            var product = await _productRepository.GetAllWithNameAsync(title);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllUserProductsAsync(Guid userId)
        {
            var product = await _productRepository.GetAllUserProductsAsync(userId);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _productRepository.RemoveAsync(id);
        }
    }
}
