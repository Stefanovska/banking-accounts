using bank_accounts_api.Models;

namespace bank_accounts_api.Services
{
	public class UserAccountTransactionsService : IUserAccountTransactionsService
    {
		public Transaction CreateTransaction(Amount amount)
		{
			return new Transaction(amount);
		} 
    }
}

