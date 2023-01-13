namespace VMix.Data.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
    }
}