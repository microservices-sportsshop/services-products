using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sports.ApplicationCore.Interfaces;
using Sports.Data.Entities;
using Sports.Persistence;

namespace Sports.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly SportsShopDbContext _sportsShopDbContext;
        private readonly ILogger<ProductsRepository> _logger;

        public ProductsRepository(SportsShopDbContext context, ILogger<ProductsRepository> logger)
        {
            _sportsShopDbContext = context ?? throw new ArgumentNullException(nameof(context));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsRepository::GetProducts()");

            return await _sportsShopDbContext.Products.ToListAsync();
        }

    }

}