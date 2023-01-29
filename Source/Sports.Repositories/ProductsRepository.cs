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

        public async Task<IEnumerable<ProductViewDto>> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsRepository::GetProducts()");

            return _mapper.Map<IEnumerable<ProductViewDto>>(
                await _sportsShopDbContext.Products.ToListAsync()
                );
        }

        public async Task<ProductViewDto?> GetProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsRepository::GetProductById()");

            return await _sportsShopDbContext.Products.FindAsync(id) is Product product
                ? _mapper.Map<ProductViewDto>(product)
                : default;
        }

        public async Task<ProductViewDto> AddProduct(ProductAddDto productAddDto)
        {
            _logger.LogInformation($"Starting ProductsRepository::AddProduct()");

            productAddDto.CreatedDate = productAddDto.ModifiedDate = DateTime.UtcNow;
            // TODO: Modified by should come from Identity Service
            productAddDto.CreatedBy = productAddDto.ModifiedBy = "Some Identity User";

            _sportsShopDbContext.Products.Add(_mapper.Map<Product>(productAddDto));
            await _sportsShopDbContext.SaveChangesAsync();

            return _mapper.Map<ProductViewDto>(productAddDto);
        }

        public async Task<ProductViewDto?> UpdateProductById(Guid id, ProductUpdateDto productUpdateDto)
        {
            _logger.LogInformation($"Starting ProductsRepository::UpdateProductById()");

            var product = await _sportsShopDbContext.Products.FindAsync(id);

            if (product is null)
            {
                return default;
            }

            _sportsShopDbContext.Entry(product).State = EntityState.Detached;

            productUpdateDto.CreatedBy = product.CreatedBy;
            productUpdateDto.CreatedDate = product.CreatedDate;
            
            productUpdateDto.ModifiedDate = DateTime.UtcNow;
            // TODO: ModifiedBy should come from Identity Service
            productUpdateDto.ModifiedBy = "Some Identity User";

            product = _mapper.Map<Product>(productUpdateDto);

            _sportsShopDbContext.Entry(product).State = EntityState.Modified;
            _ = await _sportsShopDbContext.SaveChangesAsync();

            return _mapper.Map<ProductViewDto>(product);
        }

    }

}