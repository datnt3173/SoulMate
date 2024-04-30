
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class UserMessagesConfiguration : IEntityTypeConfiguration<UserMessages>
    {
        public void Configure(EntityTypeBuilder<UserMessages> builder)
        {
            //BASE
            builder.HasKey(c => new { c.IDMessage, c.IDUser });

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<ApplicationUser>(c => c.ApplicationUser)
                .WithMany(c => c.UserMessages)
                .HasForeignKey(c => c.IDUser)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne<Messages>(c => c.Messages)
                .WithMany(c => c.UserMessages)
                .HasForeignKey(c => c.IDMessage)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
