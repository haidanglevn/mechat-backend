using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Business.Services
{
    public class ParticipantService : IParticipantService
    {
        private IParticipantRepo _participantRepo;
        public ParticipantService(IParticipantRepo participantRepo)
        {
            _participantRepo = participantRepo;
        }

        public Participant AddParticipant(Participant participant)
        {
            return _participantRepo.AddParticipant(participant);    
        }
    }
}
