using Sports.Data.Entities;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProductById(Guid id);

        //Task<CourseDto> AddCourse(CourseDto courseDto);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}