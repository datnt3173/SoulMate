
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
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

            builder.HasOne<ApplicationUser>(c=>c.ApplicationUser)
                .WithMany(c=>c.Comment)
                .HasForeignKey(c=>c.IDUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Post>(c=>c.Post)
                .WithMany(c=>c.Comment)
                .HasForeignKey(c=>c.IDPost)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
