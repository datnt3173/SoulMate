using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class ImageDataConfiguration : IEntityTypeConfiguration<ImageData>
    {
        public void Configure(EntityTypeBuilder<ImageData> builder)
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

            builder.HasOne<ApplicationUser>(c => c.ApplicationUser)
                .WithMany(c => c.ImageData)
                .HasForeignKey(c => c.IDUser)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Comment>(c => c.Comment)
               .WithMany(c => c.ImageData)
               .HasForeignKey(c => c.IDComment)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Reaction>(c => c.Reaction)
               .WithMany(c => c.ImageData)
               .HasForeignKey(c => c.IDReaction)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Post>(c => c.Post)
               .WithMany(c => c.ImageData)
               .HasForeignKey(c => c.IDPost)
               .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne<Messages>(c => c.Messages)
               .WithMany(c => c.ImageData)
               .HasForeignKey(c => c.IDMessage)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
