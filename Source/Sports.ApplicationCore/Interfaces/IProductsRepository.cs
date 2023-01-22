using Sports.Data.Entities;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        // Task<IEnumerable<CourseDto>> GetAllCourses();

        //Task<CourseDto> AddCourse(CourseDto courseDto);

        //Task<CourseDto?> GetCourseById(Guid Id);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}