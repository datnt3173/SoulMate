
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class RelationshipActionConfiguration : IEntityTypeConfiguration<RelationshipAction>
    {
        public void Configure(EntityTypeBuilder<RelationshipAction> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            // Thiết lập mối quan hệ HasOne cho IDUser
            builder.HasOne<ApplicationUser>(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.IDUser)
                   .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập mối quan hệ HasOne cho IDRelatedUser
            builder.HasOne<ApplicationUser>(c => c.RelatedUser)
                   .WithMany()
                   .HasForeignKey(c => c.IDRelatedUser)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
