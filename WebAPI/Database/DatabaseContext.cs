using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Database
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.User)
                .WithMany(u => u.Participants)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Conversation)
                .WithMany(c => c.Participants)
                .HasForeignKey(p => p.ConversationId);

            // Conversations to Messages
            modelBuilder.Entity<Conversation>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.ConversationId);

            // Users to Messages
            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId);
        }
    }
}
