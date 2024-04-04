using System.Data;
using Business.Services;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Database
{
    public class SeedData
    {
        private static PasswordHasher _passwordHasher = new();

        public static readonly Guid AdminUserGuid = Guid.Parse("ad0ad1be-f7e5-47c7-b4c3-c17250cbebab");
        public static readonly Guid User1Guid = Guid.Parse("760454fa-4af1-4ae6-9b18-ed3aec4be2a9");
        public static readonly Guid User2Guid = Guid.Parse("f015d2b2-0c84-4561-aad3-9fc8662cc938");
        public static readonly Guid User3Guid = Guid.Parse("af8ff084-f6ee-4e66-9e4a-3210e4281616");
        public static readonly Guid User4Guid = Guid.Parse("0edab5e7-6a4e-441a-8758-071c6491b293");


        public static readonly Guid ConversationId1 = Guid.Parse("1d14edc5-5dd6-4701-a010-53c1828b6ae2");
        public static readonly Guid ConversationId2 = Guid.Parse("22585025-7006-412f-b8dc-78f6a13391b7");
        public static readonly Guid ConversationId3 = Guid.Parse("76a6359b-50ce-4819-a532-ec2f4d1998e4");
        public static readonly Guid ConversationId4 = Guid.Parse("8a4185d7-c0f9-49c0-9b2e-daa30b7e556b");
        public static readonly Guid GroupConversationId = Guid.Parse("fd13300f-7829-4076-a7fd-743a49e0c59f");

        public static List<User> Users()
        {
            return new List<User>
            {
                new User {
                    Id = AdminUserGuid,
                    UserName= "admin",
                    Email = "admin@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=150",
                    Password = _passwordHasher.HashPassword("admin"),
                    Tag = "#0001",
                },
                new User {
                    Id = User1Guid,
                    UserName = "johncena",
                    Email = "cena@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=151",
                    Password = _passwordHasher.HashPassword("password"),
                    Tag = "#0002",
                },
                // Adding new users
                new User {
                    Id = User2Guid,
                    UserName = "theRock",
                    Email = "rock@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=152",
                    Password = _passwordHasher.HashPassword("password"),
                    Tag = "#0003",
                },
                new User {
                    Id = User3Guid,
                    UserName = "batista",
                    Email = "batista@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=153",
                    Password= _passwordHasher.HashPassword("password"),
                    Tag = "#0004",
                },
                new User {
                    Id = User4Guid,
                    UserName = "reyMysterio",
                    Email = "rey@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=154",
                    Password= _passwordHasher.HashPassword("password"),
                    Tag = "#0005",
                },
            };
        }

        public static List<Conversation> Conversations()
        {
            return new List<Conversation>
            {
                // Existing direct conversation
                new Conversation {
                    Id= ConversationId1,
                    ConversationType = ConversationType.Direct,
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    Title= "Test Direct Conversation"
                },
                // New direct conversations
                new Conversation {
                    Id= ConversationId2,
                    ConversationType = ConversationType.Direct,
                    CreatedAt = DateTime.UtcNow.AddDays(-9),
                    Title= "Admin and The Rock"
                },
                new Conversation {
                    Id= ConversationId3,
                    ConversationType = ConversationType.Direct,
                    CreatedAt = DateTime.UtcNow.AddDays(-8),
                    Title= "Admin and Batista"
                },
                new Conversation {
                    Id= ConversationId4,
                    ConversationType = ConversationType.Direct,
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    Title= "Admin and Rey Mysterio"
                },
                // Group conversation with all users
                new Conversation {
                    Id= GroupConversationId,
                    ConversationType = ConversationType.Group,
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    Title= "Wrestlers Chat"
                },
            };
        }

        public static List<Participant> Participants()
        {
            return new List<Participant>
            {
                // Existing participants
                new Participant {
                    ConversationId = ConversationId1,
                    UserId = AdminUserGuid,
                    NickName = "Mr Admin cute",
                    JoinDate = DateTime.UtcNow.AddDays(-10),
                },
                new Participant {
                    ConversationId = ConversationId1,
                    UserId = User1Guid,
                    NickName = "My User Man",
                    JoinDate = DateTime.UtcNow.AddDays(-10),
                },
                // Additional participants for direct conversations
                new Participant {
                    ConversationId = ConversationId2,
                    UserId = AdminUserGuid,
                    NickName = "Admin",
                    JoinDate = DateTime.UtcNow.AddDays(-9),
                },
                new Participant {
                    ConversationId = ConversationId2,
                    UserId = User2Guid,
                    NickName = "The Rock",
                    JoinDate = DateTime.UtcNow.AddDays(-9),
                },
                new Participant {
                    ConversationId = ConversationId3,
                    UserId = AdminUserGuid,
                    NickName = "Admin",
                    JoinDate = DateTime.UtcNow.AddDays(-8),
                },
                new Participant {
                    ConversationId = ConversationId3,
                    UserId = User3Guid,
                    NickName = "Batista",
                    JoinDate = DateTime.UtcNow.AddDays(-8),
                },
                new Participant {
                    ConversationId = ConversationId4,
                    UserId = AdminUserGuid,
                    NickName = "Admin",
                    JoinDate = DateTime.UtcNow.AddDays(-7),
                },
                new Participant {
                    ConversationId = ConversationId4,
                    UserId = User4Guid,
                    NickName = "Rey Mysterio",
                    JoinDate = DateTime.UtcNow.AddDays(-7),
                },
                // Group chat participants
                // Repeat for Admin, User1Guid, User2Guid, User3Guid, and User4Guid with GroupConversationId
            };
        }

        public static List<Message> Messages()
        {
            return new List<Message>
            {
                new Message {
                    Id = Guid.NewGuid(),
                    ConversationId = ConversationId1,
                    SenderId = AdminUserGuid,
                    Content = "Hey there, welcome to our chat app!",
                    CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(1),
                },
                new Message {
                    Id = Guid.NewGuid(),
                    ConversationId = ConversationId1,
                    SenderId = User1Guid,
                    Content = "Thanks! Glad to be here.",
                    CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(2),
                },
                new Message {
                    Id = Guid.NewGuid(),
                    ConversationId = ConversationId1,
                    SenderId = AdminUserGuid,
                    Content = "Feel free to ask if you have any questions.",
                    CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(3),
                },
                new Message {
                    Id = Guid.NewGuid(),
                    ConversationId = ConversationId1,
                    SenderId = User1Guid,
                    Content = "Will do! Thanks for the support.",
                    CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(4),
                },
                new Message {
                    Id = Guid.NewGuid(),
                    ConversationId = ConversationId1,
                    SenderId = AdminUserGuid,
                    Content = "Anytime! Also, let me know what features you'd like to see in the future.",
                    CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(5),
                },
                new Message {
                    Id = Guid.NewGuid(),
                    ConversationId = ConversationId1,
                    SenderId = User1Guid,
                    Content = "Sure thing, I'll keep that in mind.",
                    CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(6),
                }
            };
        }
    }
}
