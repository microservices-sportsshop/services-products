using System.ComponentModel.DataAnnotations;

namespace Sports.Data.Dtos
{
    public record ProductUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        public string Sku { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public string ModifiedBy { get; set; } = string.Empty;

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }

}
