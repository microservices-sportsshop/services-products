using Sports.Data.Dtos;
using Sports.Data.Entities;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsBusiness
    {
        Task<IEnumerable<ProductViewDto>> GetProducts();

        Task<ProductViewDto?> GetProductById(Guid id);

        Task<Product> AddProduct(ProductAddDto productAddDto);

        Task<Product?> UpdateProductById(Guid id, ProductEditDto productEditDto);

        //Task<CourseDto?> DeleteCourseById(Guid id);
    }

}