namespace ConferenceRoomBooking.Repositories
{
    public class ConferenceRoomBookingRepository
    {
       
            private readonly ConferenceRoomBookingDbContext _context;
            public ConferenceRoomBookingRepository(ConferenceRoomBookingDbContext context)
            {
                _context = context;
            }

        
    }
}
