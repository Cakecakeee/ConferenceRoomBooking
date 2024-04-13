using ConferenceRoomBooking.Models;
using Microsoft.Azure.Documents;

namespace ConferenceRoomBooking.Repositories
{
    public class UsersRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public UsersRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }

        public UsersRepository()
        {
        }

        public void Add(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
        }

        public void Remove(int userId)
        {
            var userToRemove = GetById(userId);
            if (userToRemove != null)
            {
                userToRemove.IsDeleted = true;
            }
        }

        public Users GetById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.Where(u => !u.IsDeleted).ToList();
        }

        public IEnumerable<Users> GetByName(string name)
        {
            return _context.Users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted).ToList();
        }

        public IEnumerable<Users> GetBySurname(string surname)
        {
            return _context.Users.Where(u => u.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted).ToList();
        }

        public IEnumerable<Users> GetByEmail(string email)
        {
            return _context.Users.Where(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted).ToList();
        }
    }
}

