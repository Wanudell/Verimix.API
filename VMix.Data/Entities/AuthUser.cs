namespace VMix.Data.Entities;

[Table("AuthUsers")]
public class AuthUser : BaseEntity
{
    [Required]
    [MaxLength(32)]
    public string name { get; set; }
    public string userName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string passwordHash { get; set; }
    public string token { get; set; }
    public string? qrToken { get; set; }
    public string? profilePicture { get; set; }
    public int? roleId { get; set; }
    public Guid refreshToken { get; set; }
    public DateTime? refreshTokenEndDate { get; set; }
    public DateTime? lastLoginDate { get; set; }
    public DateTime? firstLoginDate { get; set; }
}