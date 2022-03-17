using ThinkLand.DTO;

namespace ThinkLand.Service
{
    public interface ICategoryService
    {
        Task<(bool IsSuccess, Exception Exception, Category Category)> CreateAsync(Category Category);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Category Category)>UpdateAsync(Category Category);
    
    }
}