namespace ConferenceRoomBooking.Repositories
{
    public class UnavailabilityPeriodsRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public UnavailabilityPeriodsRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
    }
}
