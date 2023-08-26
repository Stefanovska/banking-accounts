using bank_accounts_api.Models;
using bank_accounts_api.Utils;

namespace bank_accounts_api.Services
{
	public class UserAccountsService : IUserAccountsService
	{
        public UserAccount AddAccount(UserAccount userAccount, string userId)
        {
            User user = MemoryStorageUtility.Users.Find(u => u.Id == userId);
            if (user == null)
            {
                throw new NullReferenceException();
            }

            if (user.UserAccounts == null)
            {
                user.UserAccounts = new List<UserAccount>();
            }
            userAccount.CustomerId = userId;
            userAccount.IsCurrent = true;
            user.UserAccounts.ForEach(ua =>
            {
                ua.IsCurrent = false;
            });
            user.UserAccounts.Add(userAccount);
            return userAccount;
        }

        public List<UserAccount> GetAccounts(string userId)
        {
            User user = MemoryStorageUtility.Users.Find(u => u.Id == userId);
            if (user == null)
            {
                throw new NullReferenceException();
            }

            if (user?.UserAccounts != null && user.UserAccounts.Count != 0)
            {
                return user.UserAccounts;
            }
            return new List<UserAccount>();
        }
    }
}

