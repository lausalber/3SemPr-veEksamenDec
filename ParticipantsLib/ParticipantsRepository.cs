using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib
{
    public class ParticipantsRepository
    {
        private static int _nextID = 1;
        private List<Participant> _participants = new();

        public ParticipantsRepository()
        {
            _participants.Add(new Participant() { ID = _nextID++, Name = "Rene Holten Poulsen", Age = 35, Country = "Denmark" });
            _participants.Add(new Participant() { ID = _nextID++, Name = "Anne-Marie Rindom", Age = 32, Country = "Denmark" });
            _participants.Add(new Participant() { ID = _nextID++, Name = "Armand Duplantis", Age = 24, Country = "Sweden" });
            _participants.Add(new Participant() { ID = _nextID++, Name = "LebBron James", Age = 39, Country = "USA" });
            _participants.Add(new Participant() { ID = _nextID++, Name = "Kevin Durant", Age = 35, Country = "USA" });
        }

        public IEnumerable<Participant> GetAll()
        {
            IEnumerable<Participant> result = new List<Participant>(_participants);
            return result;
        }

        public Participant GetByID(int id)
        {
            Participant? result = _participants.Find(participant => participant.ID == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public Participant Add(Participant participant)
        {
            participant.Validate();
            participant.ID = _nextID++;
            _participants.Add(participant);
            return participant;
        }

        public Participant Delete(int id)
        {
            Participant? participant = GetByID(id);
            if (participant == null)
            {
                return null;
            }
            _participants.Remove(participant);
            return participant;
        }
    }
}
