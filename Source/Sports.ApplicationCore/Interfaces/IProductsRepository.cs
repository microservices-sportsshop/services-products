using Sports.Data.Entities;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProductById(Guid id);

        Task<Product> AddProduct(Product product);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}