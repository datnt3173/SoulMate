﻿
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CreateDate).IsRequired();
            builder.Property(c => c.CreateBy).IsRequired();
            builder.Property(c => c.ModifiedBy).IsRequired(false);
            builder.Property(c => c.ModifiedDate).IsRequired(false);
            builder.Property(c => c.DeleteBy).IsRequired(false);
            builder.Property(c => c.DeleteDate).IsRequired(false);
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<ApplicationUser>(c=>c.ApplicationUser)
                .WithMany(c=>c.Reaction)
                .HasForeignKey(c=>c.IDUser)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne<Comment>(c=>c.Comment)
                .WithMany(c=>c.Reaction)
                .HasForeignKey(c=>c.IDComment)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne<Post>(c=>c.Post)
                .WithMany(c=>c.Reaction)
                .HasForeignKey(c=>c.IDPost)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
