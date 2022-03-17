global using Microsoft.EntityFrameworkCore;
using ThinkLand.Data;
using ThinkLand.DTO;

namespace ThinkLand.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _dbctxt;

        public ProductService(AppDBContext dbcontext)
        {
            _dbctxt = dbcontext;
        }
        public async Task<(bool IsSuccess, Exception Exception, Product Product)> CreateAsync(Product Product)
        {
            if (await ExistsAsync(Product.ID))
            {
                return (false, new ArgumentException($"There is no Product with given ID: {Product.ID}"), null);
            }

            try
            {
                await _dbctxt.products.AddAsync(Product);
                await _dbctxt.SaveChangesAsync();

                return (true, null, Product);
            }
            catch (Exception e)
            {
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            if (!await ExistsAsync(id))
            {
                return (false, new ArgumentException($"There is no Product with given ID: {id}"));
            }

            _dbctxt.products.Remove(await GetAsync(id));
            await _dbctxt.SaveChangesAsync();

            return (true, null);
        }

        public Task<bool> ExistsAsync(Guid id)
          => _dbctxt.products
        .AnyAsync(p => p.ID == id);

        public Task<List<Product>> GetAllAsync()
         => _dbctxt.products
        .AsNoTracking()
        .ToListAsync();

        public Task<Product> GetAsync(Guid id)
         => _dbctxt.products
        .AsNoTracking()
        .Where(p => p.ID == id)
        .FirstOrDefaultAsync();

        public async Task<(bool IsSuccess, Exception Exception, Product Product)> UpdateAsync(Product Product)
        {
            if (!await ExistsAsync(Product.ID))
            {
                return (false, new ArgumentException($"There is no Product with given ID: {Product.ID}"), null);
            }
            _dbctxt.products.Update(Product);
            await _dbctxt.SaveChangesAsync();

            return (true, null, Product);
        }
    }
}