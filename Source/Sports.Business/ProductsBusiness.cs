using AutoMapper;
using Microsoft.Extensions.Logging;
using Sports.ApplicationCore.Interfaces;
using Sports.Data.Dtos;

namespace Sports.Business
{
    public class ProductsBusiness : IProductsBusiness
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger<ProductsBusiness> _logger;

        public ProductsBusiness(IProductsRepository productsRepository, IMapper mapper, ILogger<ProductsBusiness> logger)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResponseDto<IEnumerable<ProductViewDto>>> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsBusiness::GetProducts()");

            return ApiResponseDto<IEnumerable<ProductViewDto>>.Create(
                    await _productsRepository.GetProducts()
                );
        }

        public async Task<ApiResponseDto<ProductViewDto?>> GetProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsBusiness::GetProductById()");

            return ApiResponseDto<ProductViewDto?>.Create(
                    await _productsRepository.GetProductById(id)
                );
        }

        public async Task<ApiResponseDto<ProductViewDto>> AddProduct(ProductAddDto productAddDto)
        {
            _logger.LogInformation($"Starting ProductsBusiness::AddProduct()");

            return ApiResponseDto<ProductViewDto>.Create(
                    await _productsRepository.AddProduct(productAddDto)
                );
        }

        public async Task<ApiResponseDto<ProductViewDto?>> UpdateProductById(Guid id, ProductUpdateDto productUpdateDto)
        {
            _logger.LogInformation($"Starting ProductsBusiness::UpdateProductById()");

            return ApiResponseDto<ProductViewDto?>.Create(
                    await _productsRepository.UpdateProductById(id, productUpdateDto)
                );
        }

    }

}