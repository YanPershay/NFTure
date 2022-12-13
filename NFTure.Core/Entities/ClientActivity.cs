using NFTure.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Core.Entities
{
    public class ClientActivity : Entity<int>
    {
        [Required]
        public string Action { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTimeOffset CreatedDateUtc { get; set; }

        [Required]
        public string EntityType { get; set; }

        // TODO: resolve foreign key
        public ClientActivityType ActivityType { get; set; }
    }
}
