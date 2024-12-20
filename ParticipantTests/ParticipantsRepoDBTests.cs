using Microsoft.EntityFrameworkCore;
using ParticipantsLib;
using ParticipantsLib.Migrations;

namespace ParticipantTests
{
    [TestClass]
    public class ParticipantsRepoDBTests
    {
        private ParticipantsRepoDB _participantsRepo;

        private ParticipantDBContext _context;

        [TestInitialize]
        public void Init()
        {
            // clean database table: remove all rows
            _context.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Participants");

            _participantsRepo = new ParticipantsRepoDB(_context);

            _participantsRepo.Add(new Participant() { Name = "Rene Holten Poulsen", Age = 35, Country = "Denmark" });
            _participantsRepo.Add(new Participant() { Name = "Anne-Marie Rindom", Age = 32, Country = "Denmark" });
            _participantsRepo.Add(new Participant() { Name = "Armand Duplantis", Age = 24, Country = "Sweden" });
            _participantsRepo.Add(new Participant() { Name = "LebBron James", Age = 39, Country = "USA" });
            _participantsRepo.Add(new Participant() { Name = "Kevin Durant", Age = 35, Country = "USA" });
        }

        [TestMethod]
        public void GetByID()
        {
            Assert.IsNull(_participantsRepo.GetByID(-1));
            Assert.IsNull(_participantsRepo.GetByID(0));
            Assert.IsNotNull(_participantsRepo.GetByID(2));
        }
    }
}