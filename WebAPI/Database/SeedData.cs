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

        public static readonly Guid ConversationId1 = Guid.Parse("1d14edc5-5dd6-4701-a010-53c1828b6ae2");



        public static List<User> Users()
        {
            return
            [
                new() {
                    Id = AdminUserGuid,
                    UserName= "admin",
                    Email = "admin@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=150",
                    Password = _passwordHasher.HashPassword("admin") ,
                    Tag = "#0001",
                },
                new() {
                    Id = User1Guid,
                    UserName = "johncena",
                    Email = "cena@mail.com",
                    Avatar = "https://picsum.photos/1000/1000?random=151",
                    Password = _passwordHasher.HashPassword("password"),
                    Tag = "#0001",
                },
            ];
        }

        public static List<Conversation> Conversations()
        {
            return
            [
                new() {
                    Id= ConversationId1,
                    ConversationType = ConversationType.Direct,
                    CreatedAt = DateTime.Now,
                    Title= "Test Direct Conversation"
                },
            ];
        }

        public static List<Participant> Participants()
        {
            return [
                new Participant()
                {
                    ConversationId = ConversationId1,
                    UserId = AdminUserGuid,
                    NickName = "Mr Admin cute",
                    JoinDate = DateTime.Now,
                },
                new Participant()
                {
                    ConversationId = ConversationId1,
                    UserId = User1Guid,
                    NickName = "My User Man",
                    JoinDate = DateTime.Now,
                },
            ];
        }

    }
}
