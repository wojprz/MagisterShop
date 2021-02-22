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
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly RefreshTokenContext _context;
        public RefreshTokenRepository(RefreshTokenContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RefreshToken token)
        {
            await _context.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetAsync(string token)
            => await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == token);

        public async Task<RefreshToken> GetByUserIdAsync(Guid userId)
            => await _context.RefreshTokens.Where(x => x.UserId == userId && x.Revoked == false).FirstOrDefaultAsync();

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
