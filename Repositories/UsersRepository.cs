using ConferenceRoomBooking.Models;
using Microsoft.Azure.Documents;

namespace ConferenceRoomBooking.Repositories
{
    
        public class UserRepository
        {
            private List<User> users;

            public UserRepository()
            {
                // Initialize the in-memory user collection
                users = new List<User>();
            }

            public void Add(User user)
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                users.Add(user);
            }

            public void Remove(int userId)
            {
                var userToRemove = GetById(userId);
                if (userToRemove != null)
                {
                    userToRemove.IsDeleted = true;
                }
            }

            public User GetById(int userId)
            {
                return users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
            }

            public IEnumerable<User> GetAll()
            {
                return users.Where(u => !u.IsDeleted).ToList();
            }

            public IEnumerable<User> GetByName(string name)
            {
                return users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted).ToList();
            }

            public IEnumerable<User> GetBySurname(string surname)
            {
                return users.Where(u => u.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted).ToList();
            }

            public IEnumerable<User> GetByEmail(string email)
            {
                return users.Where(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted).ToList();
            }
        }
    }

