using Microsoft.EntityFrameworkCore;
using ThinkLand.DAL.Interfaces;
using ThinkLand.DAL.Data;
using ThinkLand.DTO;

namespace ThinkLand.DAL.Repositories
{
    public class CategoryRepository  : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDBContext _dbctxt;
        public CategoryRepository(AppDBContext dbcontext, ILogger logger) : base(dbcontext, logger) 
        { _dbctxt = dbcontext; }

        public override async Task<(bool IsSuccess, Exception Exception, Category entity)> Add(Category Category)
        {
            if (await ExistsAsync(Category.ID))
            {
                return (false, new ArgumentException($"There is no Category with given ID: {Category.ID}"), null);
            }

            try
            {
                await _dbctxt.categories.AddAsync(Category);
                await _dbctxt.SaveChangesAsync();

                return (true, null, Category);
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
                return (false, new ArgumentException($"There is no Category with given ID: {id}"));
            }

            _dbctxt.categories.Remove(await GetById(id));
            await _dbctxt.SaveChangesAsync();

            return (true, null);
        }

        public async override Task<bool> ExistsAsync(Guid id)
          => await _dbctxt.categories
        .AnyAsync(p => p.ID == id);

        public override async Task<List<Category>> All()
         => await _dbctxt.categories
        .AsNoTracking()
        .ToListAsync();

        public override async Task<Category> GetById(Guid id)
         => await _dbctxt.categories
        .AsNoTracking()
        .Where(p => p.ID == id)
        .FirstOrDefaultAsync();

        public override async Task<(bool IsSuccess, Exception Exception, Category entity)> Update(Category Category)
        {
            if (!await ExistsAsync(Category.ID))
            {
                return (false, new ArgumentException($"There is no Category with given ID: {Category.ID}"), null);
            }
            _dbctxt.categories.Update(Category);
            await _dbctxt.SaveChangesAsync();

            return (true, null, Category);
        }
    }
}