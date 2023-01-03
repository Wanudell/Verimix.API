using System.ComponentModel.DataAnnotations.Schema;

namespace Verimix.Data.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}