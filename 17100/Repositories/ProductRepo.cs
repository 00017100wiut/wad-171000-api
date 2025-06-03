using _17100.Data;
using _17100.Models;
using Microsoft.EntityFrameworkCore;

namespace _17100.Repositories
{
    public class ProductRepo
    {
        private readonly GeneralDbContext _context;

        public ProductRepo(GeneralDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIDAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            var existing = await _context.Products.FindAsync(product.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
