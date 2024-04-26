using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class ChatRoomsConfiguration : IEntityTypeConfiguration<ChatRooms>
    {
        public void Configure(EntityTypeBuilder<ChatRooms> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifieBy).IsRequired(false);
            builder.Property(c => c.ModifieDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.Status).IsRequired();
        }
    }
}
