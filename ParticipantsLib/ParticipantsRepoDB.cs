using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib
{
    public class ParticipantsRepoDB
    {
        private readonly ParticipantDBContext _context;

        public ParticipantsRepoDB(ParticipantDBContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Participant> GetAll()
        {
            IEnumerable<Participant> result = _context.Participants;
            return result;
        }

        public Participant GetByID(int id)
        {
            Participant? result = _context.Participants.FirstOrDefault(actor => actor.ID == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public Participant Add(Participant participant)
        {
            participant.Validate();
            participant.ID = 0;
            _context.Participants.Add(participant);
            _context.SaveChanges();
            return participant;
        }

        public Participant Delete(int id)
        {
            Participant? participant = GetByID(id);
            if (participant == null)
            {
                return null;
            }
            _context.Participants.Remove(participant);
            _context.SaveChanges();
            return participant;
        }
    }
}
