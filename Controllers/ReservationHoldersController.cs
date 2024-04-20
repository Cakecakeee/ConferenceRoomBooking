using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    
    

        [ApiController]
        [Route("api/ReservationHolders")]

        public class ReservationHolderController : ControllerBase
        {
            private readonly ReservationHoldersRepository _reservationHoldersRepository;

            public ReservationHolderController(ReservationHoldersRepository reservationHoldersRepository)
            {
                _reservationHoldersRepository = reservationHoldersRepository;
            }
            [HttpPost]
            public IActionResult CreateReservationHolder(ReservationHolders reservationHolders)
            {
                try
                {
                    _reservationHoldersRepository.Create(reservationHolders);
                    return Ok("Subscription was created succesfully.");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to create subscription: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult UpdateReservationHolders(ReservationHolders reservationHolders)
            {
                try
                {
                    _reservationHoldersRepository.Update(reservationHolders);
                    return Ok("ReservationHolders was updated succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update ReservationHolders: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult SoftDeleteReservationHolders(int code)
            {
                try
                {
                    _reservationHoldersRepository.DeleteSoft(code);
                    return Ok("ReservationHolders deleted succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update ReservationHolders: {ex.Message}");
                }
            }
            [HttpDelete("ByHolder")]
            public IActionResult DeleteReservationHolders( int bookingId)
            {
                try
                {
                    _reservationHoldersRepository.DeleteSoft(bookingId);
                    return Ok("ReservationHolders deleted succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to delete ReservationHolders: {ex.Message}");
                }
            }

        }
    }


