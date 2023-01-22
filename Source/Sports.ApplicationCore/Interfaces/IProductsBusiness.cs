using Sports.Data.Dtos;

namespace Sports.ApplicationCore.Interfaces
{

    public interface IProductsBusiness
    {
        Task<IEnumerable<ProductViewDto>> GetProducts();

        Task<ProductViewDto?> GetProductById(Guid id);

        //Task<CourseDto> AddCourse(CourseDto courseDto);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}