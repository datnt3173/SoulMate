using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class MessagesUserChatRoomsConfiguration : IEntityTypeConfiguration<MessagesUserChatRooms>
    {
        public void Configure(EntityTypeBuilder<MessagesUserChatRooms> builder)
        {
            builder.HasKey(c => new {c.IDMessages, c.IDUserChatRooms});

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Messages>(c => c.Messages)
              .WithMany(c => c.MessagesUserChatRooms)
              .HasForeignKey(c => c.IDMessages)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<UserChatRooms>(c => c.UserChatRooms)
                .WithMany(c => c.MessagesUserChatRooms)
                .HasForeignKey(c => c.IDUserChatRooms)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
