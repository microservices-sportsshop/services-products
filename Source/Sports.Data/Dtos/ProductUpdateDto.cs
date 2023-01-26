using System.ComponentModel.DataAnnotations;

namespace Sports.Data.Dtos
{
    public record ProductUpdateDto : ProductAddDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string ModifiedBy { get; set; } = string.Empty;

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }

}
