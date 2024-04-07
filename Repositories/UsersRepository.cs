namespace ConferenceRoomBooking.Repositories
{
    public class UsersRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public UsersRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
    }
}
