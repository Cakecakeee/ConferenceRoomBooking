﻿using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Repositories
{
    public class BookingsRepository
    {
        private List<Bookings> bookings = new List<Bookings>();
        private Dictionary<string, int> maxRoomCapacity = new Dictionary<string, int>()
        {
            { "C001", 20 }, // Example room capacity
            { "C002", 15 },
            // Add more rooms and capacities as needed
            //coment
        };

        public string CreateBooking(Bookings booking)
        {
            // Check if room capacity is exceeded
            if (booking.NumPeople > maxRoomCapacity[booking.RoomId])
            {
                return "Booking failed. Number of people exceeds room capacity.";
            }

            // Generate booking code
            string bookingCode = GenerateBookingCode(booking.StartDate, booking.EndDate, booking.NumPeople);

            bookings.Add(booking);
            return "Booking created successfully.";
        }

        public string GenerateBookingCode(DateTime startDate, DateTime endDate, int roomId)
        {
            string code = $"{startDate:yyyyMMdd-HHmm}-{endDate:HHmm}-{roomId}";
            return code;
        }

        public Bookings GetBookingById(int id)
        {
            return bookings.Find(b => b.Id == id && !b.IsDeleted);
        }

        public List<Bookings> GetBookingsByDate(DateTime date)
        {
            return bookings.FindAll(b => b.StartDate.Date == date.Date && !b.IsDeleted);
        }

        public string UpdateBookingStatus(int id, bool isConfirmed)
        {
            Bookings booking = GetBookingById(id);
            if (booking != null)
            {
                booking.IsConfirmed = isConfirmed;
                return "Booking status updated successfully.";
            }
            return "Booking not found.";
        }

        public string SoftDeleteBooking(int id)
        {
             Bookings booking = GetBookingById(id);    
            if (booking != null)
            {
                booking.IsDeleted = true;
                return "Booking soft deleted successfully.";
            }
            return "Booking not found.";
        }

        public List<Bookings> GetAllBookings()
        {
            return bookings.FindAll(b => !b.IsDeleted);
        }

        // Admin functions
        public string GetBookingStatus(int id)
        {
            Bookings booking = GetBookingById(id);
            if (booking != null)
            {
                return booking.IsConfirmed ? "Confirmed" : "Pending";
            }
            return "Booking not found.";
        }

        public List<Bookings> GetBookingsForDate(DateTime date)
        {
            return GetBookingsByDate(date);
        }
    }

}
