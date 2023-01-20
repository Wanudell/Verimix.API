namespace VMix.Data.Entities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public int createdBy { get; set; }
    public int modifiedBy { get; set; }
    public int? deletedBy { get; set; }
    public bool isDeleted { get; set; }
    public bool isActive { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime? modifiedAt { get; set; }
    public DateTime? deletedAt { get; set; }
}