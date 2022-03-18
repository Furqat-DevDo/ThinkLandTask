using ThinkLand.DAL.Data;
using ThinkLand.DAL.Interfaces;
using ThinkLand.DTO;
using Microsoft.EntityFrameworkCore;

namespace ThinkLand.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDBContext _dbcontext;

        public ProductRepository(AppDBContext dbcontext, ILogger logger) : base(dbcontext, logger) 
        { _dbcontext = dbcontext; }
       
        public override async Task<(bool IsSuccess, Exception Exception, Product entity)> Add (Product Product)
        {
            if (await ExistsAsync(Product.ID))
            {
                return (false, new ArgumentException($"There is no Product with given ID: {Product.ID}"), null);
            }

            try
            {
                await _dbcontext.products.AddAsync(Product);
                await _dbcontext.SaveChangesAsync();

                return (true, null, Product);
            }
            catch (Exception e)
            {
                return (false, e, null);
            }
        }

        public override async Task<(bool IsSuccess, Exception Exception)> Delete(Guid id)
        {
            if (!await ExistsAsync(id))
            {
                return (false, new ArgumentException($"There is no Product with given ID: {id}"));
            }

            
            _dbcontext.products.Remove(await GetById(id));
            await _dbcontext.SaveChangesAsync();

            return (true, null);
        }

        public async override Task<bool> ExistsAsync(Guid id)
          => await _dbcontext.products
        .AnyAsync(p => p.ID == id);

        public override async Task<List<Product>> All()
         =>await _dbcontext.products
        .AsNoTracking()
        .ToListAsync();

        public override async  Task<Product> GetById(Guid id)
         => await _dbcontext.products
        .AsNoTracking()
        .Where(p => p.ID == id)
        .FirstOrDefaultAsync();

        public override async Task<(bool IsSuccess, Exception Exception, Product entity)> Update(Product Product)
        {
            if (!await ExistsAsync(Product.ID))
            {
                return (false, new ArgumentException($"There is no Product with given ID: {Product.ID}"), null);
            }
            _dbcontext.products.Update(Product);
            await _dbcontext.SaveChangesAsync();

            return (true, null, Product);
        }
    }
}
