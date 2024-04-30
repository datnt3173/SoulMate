using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public partial class ExtraInformationConfiguration : IEntityTypeConfiguration<ExtraInformation>
    {
        public void Configure(EntityTypeBuilder<ExtraInformation> builder)
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
                .WithOne(c => c.ExtraInformation)
                .HasForeignKey<ExtraInformation>(c=>c.IDUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
