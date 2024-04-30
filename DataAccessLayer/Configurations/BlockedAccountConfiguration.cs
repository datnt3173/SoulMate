using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class BlockedAccountConfiguration : IEntityTypeConfiguration<BlockedAccount>
    {
        public void Configure(EntityTypeBuilder<BlockedAccount> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<ApplicationUser>(c => c.User)
                  .WithMany(u => u.BlockedAccounts)
                  .HasForeignKey(c => c.IDUser)
                  .OnDelete(DeleteBehavior.NoAction); // Ngăn cản xóa User nếu có BlockedAccount liên quan

            builder.HasOne<ApplicationUser>(c => c.BlockedUser)
                   .WithMany()
                   .HasForeignKey(c => c.IDBlockedUser)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
