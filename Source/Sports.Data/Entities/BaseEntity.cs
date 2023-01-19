using System.ComponentModel.DataAnnotations;

namespace Sports.Data.Entities
{

    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; } = "Admin";

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public string ModifiedBy { get; set; } = "Admin";
    }

}