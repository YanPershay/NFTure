using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NFTure.Core;
using NFTure.Core.Entities;
using NFTure.Core.Entities.Auth;

namespace NFTure.Infrastructure.Data
{
    public class NftureContext : IdentityDbContext<User, Role, Guid>
    {
        public NftureContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Nft> Nfts { get; set; }
        public virtual DbSet<UserActivity> UserActivities { get; set; }
        public virtual DbSet<UserInfo> UsersInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nft>(e =>
            {
                e.HasKey(n => n.Id).HasName("PK_Nfts");

                e.Property(e => e.Id).ValueGeneratedNever();

                e.HasOne(n => n.Creator)
                 .WithMany(u => u.CreatedNfts)
                 .HasForeignKey(n => n.CreatorId)
                 .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(n => n.Owner)
                 .WithMany(u => u.OwnedNfts)
                 .HasForeignKey(n => n.OwnerId)
                 .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id)
                 .HasName("PK_Users");
            });


            modelBuilder.Entity<UserActivity>(e =>
            {
                e.HasKey(a => a.Id).HasName("PK_UserActivities");

                e.HasOne(a => a.User)
                 .WithMany(u => u.UserActivities)
                 .HasForeignKey(a => a.UserId);
            });

            modelBuilder.Entity<UserInfo>(e =>
            {
                e.HasKey(i => i.Id).HasName("PK_UsersInfo");

                e.HasOne(i => i.User)
                 .WithOne(u => u.UserInfo)
                 .HasForeignKey<UserInfo>(u => u.UserId);
            });
        }
    }
}
