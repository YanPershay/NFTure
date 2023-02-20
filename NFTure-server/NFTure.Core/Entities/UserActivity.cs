using NFTure.Core.Entities.Auth;
using NFTure.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Core.Entities
{
    public class UserActivity : Entity<int>
    {
        [Required]
        public string Action { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTimeOffset CreatedDateUtc { get; set; }

        [Required]
        public string EntityType { get; set; }

        public string ActivityType { get; set; }

        public virtual User User { get; set; }
    }
}
