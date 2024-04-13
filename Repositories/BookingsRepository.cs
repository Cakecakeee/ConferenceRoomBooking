using ConferenceRoomBooking.Models;

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
        };

        public string CreateBooking(DateTime startDate, DateTime endDate, string roomId, int numPeople)
        {
            // Check if room capacity is exceeded
            if (numPeople > maxRoomCapacity[roomId])
            {
                return "Booking failed. Number of people exceeds room capacity.";
            }

            // Generate booking code
            string bookingCode = GenerateBookingCode(startDate, endDate, roomId);

            // Create booking object
            Bookings booking = new Bookings
            {
                Id = bookings.Count + 1, // Auto-increment ID
                Code = bookingCode,
                StartDate = startDate,
                EndDate = endDate,
                RoomId = roomId,
                NumPeople = numPeople
            };

            bookings.Add(booking);
            return "Booking created successfully.";
        }

        public string GenerateBookingCode(DateTime startDate, DateTime endDate, string roomId)
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

     public class Program
    {
        static void Main(string[] args)
        {
            BookingsRepository bookingsRepo = new BookingsRepository();

            // Example usage
            DateTime startDate = new DateTime(2024, 9, 1, 8, 0, 0);
            DateTime endDate = new DateTime(2024, 9, 1, 10, 30, 0);
            string roomId = "C001";
            int numPeople = 15; // Assuming there are 15 people attending

            Console.WriteLine(bookingsRepo.CreateBooking(startDate, endDate, roomId, numPeople));

            // Example: View booking status
            int bookingId = 1; // Assuming the booking ID is 1
            Console.WriteLine(bookingsRepo.GetBookingStatus(bookingId));

            // Example: View bookings for a selected date
            DateTime selectedDate = new DateTime(2024, 9, 1);
            List<Bookings> bookingsForDate = bookingsRepo.GetBookingsForDate(selectedDate);
            foreach (var booking in bookingsForDate)

                Console.WriteLine($"Booking ID: {booking.Id}, Room ID: {booking.RoomId}, Start Date: {booking.StartDate}, End Date: {booking.EndDate}, Status: {bookingsRepo.GetBookingStatus(booking.Id)}");
        }
    }
}
