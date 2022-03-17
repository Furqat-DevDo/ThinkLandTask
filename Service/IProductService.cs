using ThinkLand.DTO;

namespace ThinkLand.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product>GetAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Product Product)> CreateAsync(Product Product);
        Task<bool> ExistsAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Product Product)> UpdateAsync(Product Product);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id); 
    }
}