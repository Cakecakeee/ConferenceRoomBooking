using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Repositories
{
    public class ReservationHoldersRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public ReservationHoldersRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
        private List<ReservationHolders> reservationHolders = new List<ReservationHolders>();
        private int nextId = 1;

        public void Create(ReservationHolders reservationHolder)
        {
            reservationHolder.Id = nextId++;
            reservationHolders.Add(reservationHolder);
        }

        public IEnumerable<ReservationHolders> List()
        {
            return reservationHolders.Where(r => !r.IsDeleted);
        }

        public ReservationHolders GetById(int id)
        {
            return reservationHolders.FirstOrDefault(r => r.Id == id && !r.IsDeleted);
        }

        public IEnumerable<ReservationHolders> Search(Func<ReservationHolders, bool> predicate)
        {
            return reservationHolders.Where(r => !r.IsDeleted && predicate(r));
        }

        public void Update(ReservationHolders updatedHolder)
        {
            var existingHolder = reservationHolders.FirstOrDefault(r => r.Id == updatedHolder.Id && !r.IsDeleted);
            if (existingHolder != null)
            {
                existingHolder.IdCardNumber = updatedHolder.IdCardNumber;
                existingHolder.Name = updatedHolder.Name;
                existingHolder.Surname = updatedHolder.Surname;
                existingHolder.Email = updatedHolder.Email;
                existingHolder.PhoneNumber = updatedHolder.PhoneNumber;
                existingHolder.Notes = updatedHolder.Notes;
            }
        }

        public void DeleteSoft(int id)
        {
            var holderToDelete = reservationHolders.FirstOrDefault(r => r.Id == id && !r.IsDeleted);
            if (holderToDelete != null)
            {
                holderToDelete.IsDeleted = true;
            }
        }

        public void DeleteBookingRelatedToHolder(int bookingId)
        {
            var bookingToDelete = reservationHolders.FirstOrDefault(r => r.BookingId == bookingId && !r.IsDeleted);
            if (bookingToDelete != null)
            {
                bookingToDelete.IsDeleted = true;
            }
        }
    }
}
