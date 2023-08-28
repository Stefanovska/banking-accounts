using bank_accounts_api.Models;
using bank_accounts_api.Utils;

namespace bank_accounts_api.Services
{
	public class UsersService : IUsersService
    {
        public User AddUser(User user)
        {
            MemoryStorageUtility.Users.Add(user);
            return user;
        }

        public List<User> GetUsers()
        {
            return MemoryStorageUtility.Users;
        }

        public User GetUser(string userId)
        {
            try
            {
                return MemoryStorageUtility.Users.Find(u => u.Id == userId);
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }

        public User UpdateUser(string userId, User user)
        {
            try
            {
                int index = MemoryStorageUtility.Users.FindIndex(u => u.Id == userId);
                MemoryStorageUtility.Users[index] = user;
                return MemoryStorageUtility.Users[index];
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }
    }
}

