using Microsoft.AspNetCore.Identity;
using NFTure.Core.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Core.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(30)]
        public override string UserName { get; set; }

        public virtual List<Nft> CreatedNfts { get; }

        public virtual List<Nft> OwnedNfts { get; }

        public virtual List<UserActivity> UserActivities { get; }

        public virtual UserInfo UserInfo { get; }
    }
}
