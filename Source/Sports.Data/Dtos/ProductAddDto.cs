﻿using System.ComponentModel.DataAnnotations;

namespace Sports.Data.Dtos
{

    public record ProductAddDto
    {
        [Required]
        public string Sku { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }

}
