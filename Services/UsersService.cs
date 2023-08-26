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
    }
}

