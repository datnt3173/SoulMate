
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class MessagesConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            // Cấu hình mối quan hệ
            builder.HasMany(c => c.UserMessages)
            .WithOne(c => c.Messages)
            .HasForeignKey(c => c.IDMessage)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ApplicationUser>(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.IDSender)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ApplicationUser>(m => m.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.IDReceiver)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
