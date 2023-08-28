using bank_accounts_api.Models;

namespace bank_accounts_api.Services
{
    public interface IUserAccountTransactionsService
    {
        Transaction CreateTransaction(Amount amount);
    }
}

