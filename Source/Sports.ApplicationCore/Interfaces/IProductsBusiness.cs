using Sports.Data.Dtos;
using Sports.Data.Entities;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsBusiness
    {
        Task<IEnumerable<ProductViewDto>> GetProducts();

        Task<ProductViewDto?> GetProductById(Guid id);

        Task<Product> AddProduct(ProductAddDto productAddDto);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}