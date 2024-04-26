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
            //builder.Entity<UserMessages>().HasNoKey();
            builder.Entity<List<DatingPurposes>>().HasNoKey();
            builder.Entity<List<PersonalPronouns>>().HasNoKey();
            builder.Entity<List<Language>>().HasNoKey();
            builder.Entity<List<Interests>>().HasNoKey();
            builder.Entity<List<Zodiac>>().HasNoKey();
            builder.Entity<List<AcademicLevel>>().HasNoKey();
            builder.Entity<List<PersonalityType>>().HasNoKey();
            builder.Entity<List<ChildDesire>>().HasNoKey();
            builder.Entity<List<CommunicationStyle>>().HasNoKey();
            builder.Entity<List<PetType>>().HasNoKey();
            builder.Entity<List<AlcoholConsumption>>().HasNoKey();
            builder.Entity<List<SmokingHabit>>().HasNoKey();
            builder.Entity<List<ExerciseHabit>>().HasNoKey();
            builder.Entity<List<DietHabit>>().HasNoKey();
            builder.Entity<List<SocialMediaActivityLevel>>().HasNoKey();
            builder.Entity<List<SleepHabit>>().HasNoKey();
            builder.Entity<List<Gender>>().HasNoKey();
            builder.Entity<List<SexualOrientation>>().HasNoKey();
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
            builder.ApplyConfiguration(new MessagesConfiguration());
            builder.ApplyConfiguration(new StyleOfLifeConfiguration());
            builder.ApplyConfiguration(new UserChatRoomsConfiguration());
            builder.ApplyConfiguration(new UserMessagesConfiguration());
        }

        private void CreateRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole() { Name = "Admin", NormalizedName = "Admin" },
                    new IdentityRole() { Name = "Client", NormalizedName = "Client" }
                );
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<ChatRooms> ChatRooms { get; set; } = null!;
        public virtual DbSet<ExtraInformation> ExtraInformation { get; set; } = null!;
        public virtual DbSet<Information> Information { get; set; } = null!;
        public virtual DbSet<Messages> Messages { get; set; } = null!;
        public virtual DbSet<StyleOfLife> StyleOfLife { get; set; } = null!;
        public virtual DbSet<UserChatRooms> UserChatRooms { get; set; } = null!;
        public virtual DbSet<UserMessages> UserMessages { get; set; } = null!;
    }
}