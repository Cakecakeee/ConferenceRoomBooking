namespace ConferenceRoomBooking.Repositories
{
    public class ReservationHoldersRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public ReservationHoldersRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
    }
}
