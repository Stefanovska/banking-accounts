using bank_accounts_api.Models;

namespace bank_accounts_api.Services
{
    public interface IUserAccountsService
    {
        UserAccount AddAccount(UserAccount userAccount, string userId);
        List<UserAccount> GetAccounts(string userId);
    }
}

