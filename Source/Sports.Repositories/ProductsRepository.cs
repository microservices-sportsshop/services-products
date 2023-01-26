using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sports.ApplicationCore.Interfaces;
using Sports.Data.Dtos;
using Sports.Data.Entities;
using Sports.Persistence;

namespace Sports.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly SportsShopDbContext _sportsShopDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsRepository> _logger;

        public ProductsRepository(SportsShopDbContext sportsShopDbContext, IMapper mapper, ILogger<ProductsRepository> logger)
        {
            _sportsShopDbContext = sportsShopDbContext ?? throw new ArgumentNullException(nameof(sportsShopDbContext));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsRepository::GetProducts()");

            return await _sportsShopDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsRepository::GetProductById()");

            return await _sportsShopDbContext.Products.FindAsync(id) is Product product ? product : default;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _logger.LogInformation($"Starting ProductsRepository::AddProduct()");

            _sportsShopDbContext.Products.Add(product);
            await _sportsShopDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> UpdateProductById(Guid id, ProductUpdateDto productUpdateDto)
        {
            _logger.LogInformation($"Starting ProductsRepository::UpdateProductById()");

            var product = await _sportsShopDbContext.Products.FindAsync(id);

            if (product is null)
            {
                return product;
            }

            product = _mapper.Map<ProductUpdateDto, Product>(productUpdateDto);

            _sportsShopDbContext.Entry(product).State = EntityState.Modified;
            _ = await _sportsShopDbContext.SaveChangesAsync();

            return product;
        }

    }

}