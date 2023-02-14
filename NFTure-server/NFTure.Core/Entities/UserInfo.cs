using NFTure.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Core.Entities
{
    public class UserInfo : Entity<int>
    {
        [Required]
        public Guid UserId { get; set; }

        [Url]
        public string? AvatarUrl { get; set; }

        [MaxLength(30)]
        public string? FirstName { get; set; }

        [MaxLength(30)]
        public string? LastName { get; set; }

        public bool? IsVerified { get; set; }

        public virtual User User { get; set; }
    }
}
