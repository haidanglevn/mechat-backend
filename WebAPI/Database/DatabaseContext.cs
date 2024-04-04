using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Database
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Participant> Participants { get; set; }

        static DatabaseContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DatabaseContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("LocalDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enums setup 
            modelBuilder.HasPostgresEnum<FriendshipStatus>();
            modelBuilder.HasPostgresEnum<ConversationType>();


            base.OnModelCreating(modelBuilder);

            // Seed Data setup
            modelBuilder.Entity<User>().HasData(SeedData.Users());
            modelBuilder.Entity<Conversation>().HasData(SeedData.Conversations());
            modelBuilder.Entity<Participant>().HasData(SeedData.Participants());
            modelBuilder.Entity<Message>().HasData(SeedData.Messages());

            // User to Friendships
            modelBuilder.Entity<User>()
                .HasMany(u => u.SentFriendships)
                .WithOne(f => f.Requestor)
                .HasForeignKey(f => f.RequestorId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedFriendships)
                .WithOne(f => f.Receiver)
                .HasForeignKey(f => f.ReceiverId);

            // Users, Participants, and Conversations (Many-to-Many)
            modelBuilder.Entity<Participant>()
                .HasKey(p => new { p.UserId, p.ConversationId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne()
                .HasForeignKey(m => m.SenderId);

            modelBuilder.Entity<Conversation>()
                .HasMany(c=> c.Messages)
                .WithOne()
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
