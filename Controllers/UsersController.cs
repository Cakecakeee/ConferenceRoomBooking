using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace ConferenceRoomBooking.Controllers
{
    
        public class UserController : ControllerBase
        {
            private readonly UsersRepository userRepository;

            public UserController()
            {
                
                userRepository = new UsersRepository();
            }

            
            public IEnumerable<User> GetAllUsers()
            {
                return (IEnumerable<User>)userRepository.GetAll();
            }

           
            public ActionResult GetUserById(int id)
            {
                var user = userRepository.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            
            public ActionResult PostUser(Users user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                userRepository.Add(user);

                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }

            
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

