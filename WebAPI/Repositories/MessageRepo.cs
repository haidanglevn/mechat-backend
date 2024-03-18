using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;

namespace WebAPI.Repositories
{
    public class MessageRepo : IMessageRepo
    {
        private DbSet<Message> _messages;
        private DatabaseContext _database;

        public MessageRepo(DatabaseContext database)
        {
            _database = database;
            _messages = database.Messages;
        }
        public Message SendMessage(Message message)
        {
            _messages.Add(message); 
            _database.SaveChanges();
            return message;
        }
    }
}
