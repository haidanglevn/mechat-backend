using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IParticipantService
    {
        Participant AddParticipant(Participant participant);
    }
}
