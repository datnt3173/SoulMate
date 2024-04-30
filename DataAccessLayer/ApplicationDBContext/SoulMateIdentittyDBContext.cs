using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Intermediate;
using DataAccessLayer.Configurations;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using static DataAccessLayer.Entities.Base.EnumBase;
namespace DataAccessLayer.ApplicationDBContext
{
    public class SoulMateIdentittyDBContext : IdentityDbContext<IdentityUser>
    {
        public SoulMateIdentittyDBContext()
        {
        }

        public SoulMateIdentittyDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=SoulMate;Integrated Security=True;TrustServerCertificate=True"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            CreateRoles(builder);
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>()
                .ToTable("AspNetUsers")
                .HasIndex(u => u.Email)
                .IsUnique();

            //builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ExtraInformationConfiguration());
            builder.ApplyConfiguration(new ChatRoomsConfiguration());
            builder.ApplyConfiguration(new InformationConfiguration());
            builder.ApplyConfiguration(new RelationshipActionConfiguration());
            builder.ApplyConfiguration(new MessagesConfiguration());
            builder.ApplyConfiguration(new StyleOfLifeConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ReactionConfiguration());
            builder.ApplyConfiguration(new UserChatRoomsConfiguration());
            builder.ApplyConfiguration(new UserMessagesConfiguration());
            builder.ApplyConfiguration(new ImageDataConfiguration());
            builder.ApplyConfiguration(new MessagesUserChatRoomsConfiguration());
            builder.ApplyConfiguration(new BlockedAccountConfiguration());
        }

        private void CreateRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole() { Name = "Admin", NormalizedName = "Admin" },
                    new IdentityRole() { Name = "Client", NormalizedName = "Client" }
                );
        }
        public DbSet<MessagesUserChatRooms> MessagesUserChatRooms { get; set; }
        public virtual DbSet<BlockedAccount> BlockedAccount { get; set; } = null!;
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<RelationshipAction> RelationshipAction { get; set; } = null!;
        public virtual DbSet<ChatRooms> ChatRooms { get; set; } = null!;
        public virtual DbSet<ExtraInformation> ExtraInformation { get; set; } = null!;
        public virtual DbSet<Information> Information { get; set; } = null!;
        public virtual DbSet<Messages> Messages { get; set; } = null!;
        public virtual DbSet<StyleOfLife> StyleOfLife { get; set; } = null!;
        public virtual DbSet<UserChatRooms> UserChatRooms { get; set; } = null!;
        public virtual DbSet<UserMessages> UserMessages { get; set; } = null!;
        public virtual DbSet<Post> Post { get; set; } = null!;
        public virtual DbSet<Comment> Comment { get; set; } = null!;
        public virtual DbSet<ImageData> ImageData { get; set; } = null!;
        public virtual DbSet<Reaction> Reaction { get; set; } = null!;
    }
}