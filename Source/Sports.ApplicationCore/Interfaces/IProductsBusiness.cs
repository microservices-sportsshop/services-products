using Sports.Data.Dtos;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsBusiness
    {
        Task<IEnumerable<ProductViewDto>> GetProducts();

        // Task<IEnumerable<CourseDto>> GetAllCourses();

        //Task<CourseDto> AddCourse(CourseDto courseDto);

        //Task<CourseDto?> GetCourseById(Guid Id);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}