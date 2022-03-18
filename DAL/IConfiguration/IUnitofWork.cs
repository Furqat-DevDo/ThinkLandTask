using ThinkLand.DAL.Interfaces;

namespace ThinkLand.DAL.IConfiguration
{
    public interface IUnitofWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task CompleteAsync();
    }
}
