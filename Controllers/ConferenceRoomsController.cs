using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConferenceRoomBooking.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ConferenceRoomsControllers : ControllerBase
        {
            private readonly ConferenceRoomsRepository _repository;
            public ConferenceRoomsControllers(ConferenceRoomsRepository repository)
            {
                _repository = repository;
            }
            // GET: api/ConferenceRooms
            [HttpGet]
            public ActionResult<List<ConferenceRooms>> GetConferenceRooms()
            {
                return _repository.GetAll();
            }
            // GET: api/ConferenceRooms/5
            [HttpGet("{id}")]
            public ActionResult<ConferenceRooms> GetConferenceRoom(int id)
            {
                var conferenceRoom = _repository.GetRoomById(id);
                if (conferenceRoom == null)
                {
                    return NotFound();
                }
                return conferenceRoom;
            }
            // GET: api/ConferenceRooms/5
            [HttpGet("{code}")]
            public ActionResult<ConferenceRooms> GetConferenceRoom(string id)
            {
                var conferenceRoom = _repository.GetRoomByCode(id);
                if (conferenceRoom == null)
                {
                    return NotFound();
                }
                return conferenceRoom;
            }
            // POST: api/ConferenceRooms
            [HttpPost]
            public ActionResult PostConferenceRoom(ConferenceRooms conferenceRoom)
            {
                _repository.CreateRoom(conferenceRoom);
                return CreatedAtAction(nameof(GetConferenceRoom), new { id = conferenceRoom.Id }, conferenceRoom);
            }
            // PUT: api/ConferenceRooms/5
            [HttpPut]
            public IActionResult UpdateConferenceRooms(ConferenceRooms conferenceRooms)
            {
                try
                {
                    _repository.UpdateRoom(conferenceRooms);
                    return Ok("ConferenceRooms was updated succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update ConferenceRooms: {ex.Message}");
                }
            }
            // DELETE: api/ConferenceRooms/5
            [HttpDelete("{id}")]
            public IActionResult SoftDeleteConferenceRooms(int code)
            {
                try
                {
                    _repository.DeleteRoom(code);
                    return Ok("ConferenceRooms deleted succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update ConferenceRooms: {ex.Message}");
                }
            }
        }
    }




















