using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sports.Data.Entities
{

    public class Product : BaseEntity
    {
        [Required]
        public string Sku { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category? Category { get; set; }
    }

}