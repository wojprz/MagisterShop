using MagisterShop.Domain.Entities;
using MagisterShop.Infraastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Infraastructure.Services
{
    public interface IProductService
    {
        Task CreateAsync(Product product, Guid userId);
        Task<ProductDTO> GetAsync(Guid id);
        Task<IEnumerable<ProductDTO>> GetAllAsync(int page, int count = 10);
        Task<IEnumerable<ProductDTO>> GetAllWithNameAsync(string title);
        Task<IEnumerable<ProductDTO>> GetAllUserProductsAsync(Guid userId);
        Task RemoveAsync(Guid id);
    }
}
