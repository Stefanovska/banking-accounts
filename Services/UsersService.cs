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
	}
}

