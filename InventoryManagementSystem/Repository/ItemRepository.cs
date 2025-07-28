using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class ItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Items.FindAsync(id);
        }

        public async Task AddAsync(Item item)
        {
            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _dbContext.Items.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _dbContext.Items.FindAsync(id);
            if (item != null)
            {
                _dbContext.Items.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStatusAsync(Guid id, InventoryStatus status)
        {
            var item = await _dbContext.Items.FindAsync(id);
            if (item != null)
            {
                item.Status = status;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Item>> SearchAsync(
           string? name = null,
           string? category = null,
           InventoryStatus? status = null,
           decimal? minPrice = null,
           decimal? maxPrice = null,
           int? minQuantity = null,
           int? maxQuantity = null)
        {
            var query = _dbContext.Items.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(i => EF.Functions.Like(i.Name, $"%{name}%"));

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(i => EF.Functions.Like(i.Category, $"%{category}%"));

            if (status.HasValue)
                query = query.Where(i => i.Status == status.Value);

            if (minPrice.HasValue)
                query = query.Where(i => i.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(i => i.Price <= maxPrice.Value);

            if (minQuantity.HasValue)
                query = query.Where(i => i.Quantity >= minQuantity.Value);

            if (maxQuantity.HasValue)
                query = query.Where(i => i.Quantity <= maxQuantity.Value);

            return await query.ToListAsync();
        }

    }
}
