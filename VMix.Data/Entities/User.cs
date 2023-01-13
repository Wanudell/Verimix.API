namespace VMix.Data.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(32)]
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
		public Guid RefreshToken { get; set; }
        public DateTime ExpiresInMinutes { get; set; }
	}
}