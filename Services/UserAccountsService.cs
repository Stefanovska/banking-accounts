using bank_accounts_api.Models;

namespace bank_accounts_api.Services
{
	public class UserAccountsService : IUserAccountsService
	{
        private readonly IUsersService _usersService;
        private readonly IUserAccountTransactionsService _userAccountTransactionsService;

        public UserAccountsService(
            IUsersService usersService,
            IUserAccountTransactionsService userAccountTransactionsService
        )
        {
            _usersService = usersService;
            _userAccountTransactionsService = userAccountTransactionsService;
        }

        public UserAccount AddAccount(UserAccount userAccount, string userId)
        {
            User user = _usersService.GetUser(userId);
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

            if (userAccount.InitialCredit.Value != 0)
            {
                Transaction transaction = _userAccountTransactionsService.CreateTransaction(userAccount.InitialCredit);
                if (userAccount.Transactions == null)
                {
                    userAccount.Transactions = new List<Transaction>();
                }
                userAccount.Transactions.Add(transaction);
            }

            user.UserAccounts.Add(userAccount);

            float totalBalance = 0;
            user.UserAccounts.ForEach(ua =>
            {
                if (ua.Transactions != null)
                {
                    ua.Transactions.ForEach(t =>
                    {
                        if (t.Amount != null)
                        {
                            totalBalance += t.Amount.Value;
                        } else
                        {
                            totalBalance += 0;
                        }
                        
                    });
                }
            });

            user.Balance = new Amount(totalBalance, "EUR");
            _usersService.UpdateUser(user.Id, user);

            return userAccount;
        }

        public List<UserAccount> GetAccounts(string userId)
        {
            User user = _usersService.GetUser(userId);
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

