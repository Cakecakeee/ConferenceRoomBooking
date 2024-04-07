namespace ConferenceRoomBooking.Repositories
{
    public class ConferenceRoomsRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public ConferenceRoomsRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
    }
}
