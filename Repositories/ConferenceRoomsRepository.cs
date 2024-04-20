using ConferenceRoomBooking.Migrations;
using ConferenceRoomBooking.Models;
namespace ConferenceRoomBooking.Repositories
{
    public class ConferenceRoomsRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public ConferenceRoomsRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
        public void CreateRoom(ConferenceRooms room)
        {
            _context.ConferenceRooms.Add(room);
            _context.SaveChanges();
        }
        public ConferenceRooms GetRoomById(int id)
        {
            return _context.ConferenceRooms.Find(id);
        }
        public List<ConferenceRooms> GetAll()
        {
            return _context.ConferenceRooms.ToList();
        }
        public ConferenceRooms GetRoomByCode(string code)
        {
            return _context.ConferenceRooms.Find(code);
        }
        public void UpdateRoom(ConferenceRooms room)
        {
            var exists = _context.ConferenceRooms.Find(room.Id);
            if (exists != null)
            {
                _context.ConferenceRooms.Update(room);
            }
            _context.SaveChanges();
        }
        public void DeleteRoom(int id)
        {
            var room = _context.ConferenceRooms.Find(id);
            _context.ConferenceRooms.Remove(room);
            _context.SaveChanges();
        }
    }
}





















