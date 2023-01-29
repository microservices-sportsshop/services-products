using Sports.Data.Dtos;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsRepository
    {
        Task<IEnumerable<ProductViewDto>> GetProducts();

        Task<ProductViewDto?> GetProductById(Guid id);

        Task<ProductViewDto> AddProduct(ProductAddDto productAddDto);

        Task<ProductViewDto?> UpdateProductById(Guid id, ProductUpdateDto productUpdateDto);

        //Task<CourseDto?> DeleteCourseById(Guid id);
    }

}