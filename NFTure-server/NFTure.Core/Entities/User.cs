using NFTure.Core.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Core.Entities
{
    public class User : Entity<Guid>
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        public virtual List<Nft> CreatedNfts { get; }

        public virtual List<Nft> OwnedNfts { get; }

        public virtual List<UserActivity> UserActivities { get; }

        public virtual UserInfo UserInfo { get; }
    }
}
