using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    
        [ApiController]
        [Route("api/UnavailabilityPeriods")]
        public class UnavailabilityPeriodsControllers : ControllerBase
        {
            private readonly UnavailabilityPeriodsRepository _unavailabilityPeriodsRepository;
            public UnavailabilityPeriodsControllers(UnavailabilityPeriodsRepository unavailabilityPeriodsRepository)
            {
                _unavailabilityPeriodsRepository = unavailabilityPeriodsRepository;
            }

            [HttpPost]
            public IActionResult CreateUnavailabilityPeriods(UnavailabilityPeriods periods)
            {
                try
                {
                    _unavailabilityPeriodsRepository.Create(periods);
                    return Ok("UnavailabilityPeriods was created succesfully.");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to create UnavailabilityPeriods: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult UpdateUnavailabilityPeriods(UnavailabilityPeriods periods)
            {
                try
                {
                    _unavailabilityPeriodsRepository.Update(periods);
                    return Ok("UnavailabilityPeriods was updated succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update UnavailabilityPeriods: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult SoftDeleteUnaivailibilityPeriods(int code)
            {
                try
                {
                    _unavailabilityPeriodsRepository.DeleteSoft(code);
                    return Ok("UnavailabilityPeriods deleted succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update UnavailabilityPeriods: {ex.Message}");
                }
            }

        }
    }

