using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;

namespace WebAPI.Repositories
{
    public class ParticipantRepo : IParticipantRepo
    {
        private DbSet<Participant> _participants;
        private DatabaseContext _database;
        public ParticipantRepo(DatabaseContext database)
        {
            _database = database;
            _participants = database.Participants;
        }
        public Participant AddParticipant(Participant participant)
        {
           _participants.Add(participant);
            _database.SaveChanges();
            return participant;
        }
    }
}
