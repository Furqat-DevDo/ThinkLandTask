using ThinkLand.Data;
using ThinkLand.DTO;

namespace ThinkLand.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _dbctxt;

        public CategoryService(AppDBContext dbcontext)
        {
            _dbctxt=dbcontext;
        }
         public async Task<(bool IsSuccess, Exception Exception, Category Category)> CreateAsync(Category Category)
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

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            if (!await ExistsAsync(id))
            {
                return (false, new ArgumentException($"There is no Category with given ID: {id}"));
            }

            _dbctxt.categories.Remove(await GetAsync(id));
            await _dbctxt.SaveChangesAsync();

            return (true, null);
        }

        public Task<bool> ExistsAsync(Guid id)
          => _dbctxt.categories
        .AnyAsync(p => p.ID == id);

        public Task<List<Category>> GetAllAsync()
         => _dbctxt.categories
        .AsNoTracking()
        .ToListAsync();

        public Task<Category> GetAsync(Guid id)
         => _dbctxt.categories
        .AsNoTracking()
        .Where(p => p.ID == id)
        .FirstOrDefaultAsync();

        public async Task<(bool IsSuccess, Exception Exception, Category Category)> UpdateAsync(Category Category)
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