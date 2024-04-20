using ConferenceRoomBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using ConferenceRoomBooking.Models;
namespace ConferenceRoomBooking.Controllers
{
   
    
        [ApiController]
        [Route("api/Bookings")]
        public class BookingController : ControllerBase
        {
            private readonly BookingsRepository _bookingsRepository;
            public BookingController(BookingsRepository bookingsRepository)
            {
                _bookingsRepository = bookingsRepository;
            }
            [HttpGet("All")]
            public IActionResult GetAllBookings()
            {
                try
                {
                    IEnumerable<Bookings> bookings = _bookingsRepository.GetAllBookings();
                    return Ok(bookings);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to retrieve all bookings:{ex.Message}");
                }
            }
            [HttpGet("{id}")]
            public IActionResult GetBookingById(int id)
            {
                try
                {
                    var bookings = _bookingsRepository.GetBookingById(id);
                    return Ok(bookings);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to get id:{ex.Message}");
                }
            }
            [HttpPost]
            public IActionResult CreateBookings(Bookings booking)
            {
                try
                {
                    _bookingsRepository.CreateBooking(booking);
                    return Ok("Booking was created succesfully.");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to create booking: {ex.Message}");
                }
            }
            [HttpPut]
            public IActionResult UpdateBookings(int id, bool isConfirmed)
            {
                try
                {
                    _bookingsRepository.UpdateBookingStatus(id, isConfirmed);
                    return Ok("Booking was updated succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to update booking: {ex.Message}");
                }
            }
            [HttpDelete]
            public IActionResult SoftDeleteBookings(int code)
            {
                try
                {
                    _bookingsRepository.SoftDeleteBooking(code);
                    return Ok("Booking deleted succesfully.");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Failed to delete bookings: {ex.Message}");
                }
            }
        }
    }























