using System.ComponentModel.DataAnnotations;

namespace Sports.Data.Dtos
{

    public record ProductUpdateDto : ProductAddDto
    {
        [Required]
        public Guid Id { get; set; }
    }

}
