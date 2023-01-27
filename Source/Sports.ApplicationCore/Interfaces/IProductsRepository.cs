using Sports.Data.Dtos;
using Sports.Data.Entities;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProductById(Guid id);

        Task<Product> AddProduct(Product product);

        Task<Product?> UpdateProductById(Guid id, ProductUpdateDto productUpdateDto);

        //Task<CourseDto?> DeleteCourseById(Guid id);
    }

}