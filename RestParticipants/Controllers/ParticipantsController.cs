using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParticipantsLib;

namespace RestParticipants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private ParticipantsRepository _repo;

        public ParticipantsController(ParticipantsRepository participantsRepo)
        {
            _repo = participantsRepo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Participant>> Get()
        {
            IEnumerable<Participant> result = _repo.GetAll();
            if (result == null)
            {
                return NotFound("List was not found");
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Participant> Get(int id)
        {
            Participant result = _repo.GetByID(id);
            if (result == null)
            {
                return NotFound("(\"No such participant, id: \"" + id);
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Participant?> Post([FromBody] Participant participant)
        {
            Participant newParticipant = _repo.Add(participant);
            if (newParticipant == null)
            {
                return BadRequest(newParticipant);
            }
            return Created("", newParticipant);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Participant?> Delete(int id)
        {
            if (_repo.GetByID(id) == null)
            {
                return NotFound(id);
            }
            Participant deletedPhoto = _repo.Delete(id);

            return Ok(deletedPhoto);
        }
    }
}
