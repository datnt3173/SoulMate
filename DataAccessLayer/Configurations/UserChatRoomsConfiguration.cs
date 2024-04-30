using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class UserChatRoomsConfiguration : IEntityTypeConfiguration<UserChatRooms>
    {
        public void Configure(EntityTypeBuilder<UserChatRooms> builder)
        {
            //BASE
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<ApplicationUser>(c => c.ApplicationUser)
                .WithMany(c => c.UserChatRooms)
                .HasForeignKey(c => c.IDUser)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ChatRooms>(c => c.ChatRooms)
                .WithMany(c => c.UserChatRooms)
                .HasForeignKey(c => c.IDChatRoom)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
