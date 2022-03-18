using ThinkLand.DAL.IConfiguration;
using ThinkLand.DAL.Interfaces;
using ThinkLand.DAL.Repositories;

namespace ThinkLand.DAL.Data
{
    public class UnitOfWork : IUnitofWork, IDisposable
    {
        private readonly AppDBContext _context;
        private readonly ILogger _logger;

        public IProductRepository Products { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(AppDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Products = new ProductRepository(context, _logger);
            Categories = new CategoryRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
