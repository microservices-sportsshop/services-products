using AutoMapper;
using Microsoft.Extensions.Logging;
using Sports.ApplicationCore.Interfaces;
using Sports.Data.Dtos;
using Sports.Data.Entities;

namespace Sports.Business
{
    public class ProductsBusiness : IProductsBusiness
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsBusiness> _logger;

        public ProductsBusiness(IProductsRepository productsRepository, IMapper mapper, ILogger<ProductsBusiness> logger)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductViewDto>> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsBusiness::GetProducts()");

            var products = await _productsRepository.GetProducts();

            return _mapper.Map<List<ProductViewDto>>(products);
        }

        public async Task<ProductViewDto?> GetProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsBusiness::GetProductById()");

            var product = await _productsRepository.GetProductById(id);

            return _mapper.Map<ProductViewDto>(product);
        }

        public async Task<Product> AddProduct(ProductAddDto productAddDto)
        {
            _logger.LogInformation($"Starting ProductsBusiness::AddProduct()");

            var product = await _productsRepository.AddProduct(_mapper.Map<Product>(productAddDto));

            return product;
        }

        public async Task<Product?> UpdateProductById(Guid id, ProductEditDto productEditDto)
        {
            _logger.LogInformation($"Starting ProductsBusiness::UpdateProductById()");

            var product = await _productsRepository.UpdateProductById(id, _mapper.Map<Product>(productEditDto));

            return product;
        }

    }

}