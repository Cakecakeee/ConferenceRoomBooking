using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
namespace ConferenceRoomBooking.Controllers
{

    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly UsersRepository userRepository;
        public UserController(UsersRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return (IEnumerable<User>)userRepository.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public ActionResult PostUser(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userRepository.Add(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [HttpDelete]

        public ActionResult DeleteUser(int id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            userRepository.Remove(id);
            return Ok(user);
        }
    }
}