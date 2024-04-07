namespace ConferenceRoomBooking.Repositories
{
    public class BookingsRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public BookingsRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
    }
}
