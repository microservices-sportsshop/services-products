using System.ComponentModel.DataAnnotations;

namespace Sports.Data.Entities
{

    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public string? ModifiedBy { get; set; }
    }

}