using Sports.Data.Entities;

namespace Sports.Data.Dtos
{

    public record ProductDto
    {
        public Guid Id { get; set; }

        public string Sku { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }
    }

}
