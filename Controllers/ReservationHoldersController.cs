using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    public class ReservationHoldersController
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
            public IActionResult UpdateSubscriptions(Subscription subscription)
            {
                try
                {
                    _subscriptionsRepository.UpdateSubscription(subscription);
                    return Ok("Subscription was updated succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update subscription: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult SoftDeleteSubscriptions(int code)
            {
                try
                {
                    _subscriptionsRepository.SoftDelete(code);
                    return Ok("Subscription deleted succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update subscription: {ex.Message}");
                }
            }


        }
    }
}

