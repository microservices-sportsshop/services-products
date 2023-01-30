using Sports.Data.Dtos;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsBusiness
    {
        Task<ApiResponseDto<IEnumerable<ProductViewDto>>> GetProducts();

        Task<ApiResponseDto<ProductViewDto?>> GetProductById(Guid id);

        Task<ApiResponseDto<ProductViewDto>> AddProduct(ProductAddDto productAddDto);

        Task<ApiResponseDto<ProductViewDto?>> UpdateProductById(Guid id, ProductUpdateDto productUpdateDto);

        //Task<CourseDto?> DeleteCourseById(Guid id);
    }

}