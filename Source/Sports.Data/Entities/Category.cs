namespace Sports.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual List<Product>? Products { get; set; }
    }
}
