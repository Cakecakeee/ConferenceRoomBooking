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
        private List<ConferenceRooms> rooms;

        public ConferenceRoomsRepository()
        {
            rooms = new List<ConferenceRooms>();
        }

        public void CreateRoom(ConferenceRooms rooms)
        {
            _context.ConferenceRooms.Add(rooms);
        }

        public ConferenceRooms GetRoomById(int id)
        {
            return rooms.Find(r => r.Id == id);
        }

        public ConferenceRooms GetRoomByCode(string code)
        {
            return rooms.Find(r => r.Code == code);
        }

        public void UpdateRoom(ConferenceRooms room)
        {
            int index = rooms.FindIndex(r => r.Id == room.Id);
            if (index != -1)
            {
                rooms[index] = room;
            }
        }

        public void DeleteRoom(int id)
        {
            rooms.RemoveAll(r => r.Id == id);
        }
    }
}
