namespace Verimix.Data.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(32)]
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}